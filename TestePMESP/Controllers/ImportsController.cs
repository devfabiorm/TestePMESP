using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TestePMESP.Models;
using TestePMESP.Services;

namespace TestePMESP.Controllers
{
    [ApiController]
    public class ImportsController : ControllerBase
    {
        private readonly IRepository<Import> _repo;
        private List<Product> products = new List<Product>();

        public ImportsController(IRepository<Import> repository)
        {
            _repo = repository;
        }

        [HttpPost]
        [Route("/importacao")]
        public async Task<IActionResult> Insert(IFormFile file)
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

                            Console.WriteLine(totalRows);
                            for (int row = 2; row < totalRows; row++)
                            {
                                Product product = null;


                                Console.WriteLine(package.Workbook.Worksheets[i].Cells[row, 1].Value.ToString());
                                var deliveryDate = DateTime.Parse(package.Workbook.Worksheets[i].Cells[row, 1].Value.ToString());
                                var productDescription = package.Workbook.Worksheets[i].Cells[row, 2].Value.ToString();
                                var productQuantity = Int32.Parse(package.Workbook.Worksheets[i].Cells[row, 3].Value.ToString());
                                var unitaryPrice = Double.Parse(package.Workbook.Worksheets[i].Cells[row, 4].Value.ToString());

                                product = new Product(deliveryDate, productDescription, productQuantity, unitaryPrice);


                                products.Add(product);
                            }
                        }
                        //Salvar no banco
                        _repo.Insert(new Import()
                        {
                            Products = products
                        });
                        //Retornar Lista do banco
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
