using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TestePMESP.Models;

namespace TestePMESP.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //private Product product = new Product();

        [HttpPost]
        [Route("/upload/product")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentException("É necessário um arquivo para uplload", nameof(file));
                }


                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream).ConfigureAwait(false);

                    using (var package = new ExcelPackage(memoryStream))
                    {
                        for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                        {
                            var totalRows = package.Workbook.Worksheets[i].Dimension?.Rows;
                            //var totalColumns = package.Workbook.Worksheets[i].Dimension?.Columns;


                            for (int row = 1; row <= totalRows; row++)
                            {

                                if (row != 1)
                                {
                                    var deliveryDate = DateTime.Parse(package.Workbook.Worksheets[i].Cells[row, 1].Value.ToString());
                                    var productDescription = package.Workbook.Worksheets[i].Cells[row, 2].Value.ToString();
                                    var productQuantity = Int32.Parse(package.Workbook.Worksheets[i].Cells[row, 3].Value.ToString());
                                    var unitaryPrice = Double.Parse(package.Workbook.Worksheets[i].Cells[row, 4].Value.ToString());

                                    new Product(deliveryDate, productDescription, productQuantity, unitaryPrice);
                                }
                            }
                        }

                        return NoContent();
                    }
                }
            }
            catch (ArgumentException e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
