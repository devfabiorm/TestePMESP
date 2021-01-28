using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using TestePMESP.Helpers;
using TestePMESP.Models;
using TestePMESP.Services;
using TestePMESP.Views;

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

        [HttpGet]
        [Route("/importacao")]
        public IEnumerable<ImportApi> GetImportacoes()
        {
            var listImports = new List<ImportApi>();
            var calc = new CalcImport();

            var imports = _repo
                .All
                .Include(i => i.Products)
                .ToList();


            for (int i = 0; i < imports.Count; i++)
            {
                var closerDate = calc.GetCloserDate(imports[i].Products);
                var importId = imports[i].Id;
                var importDate = imports[i].ImportDate;
                var numItems = imports[i].Products.Count;
                var totalImport = calc.GetTotalImport(imports[i].Products);

                listImports.Add(new ImportApi()
                {
                    CloserDate = closerDate,
                    ImportId = importId,
                    ImportDate = importDate,
                    NumItems = numItems,
                    Total = totalImport
                });
            }

            return listImports;
        }

        [HttpGet]
        [Route("/importacao/{id?}")]
        public IEnumerable<ProductApi> GetImportacao(int id)
        {
            var products = new List<ProductApi>();
            var import = _repo.Find(id);

            if(import == null)
            {
                return (IEnumerable<ProductApi>)BadRequest();
            }

            foreach (var item in import.Products)
            {
                products.Add(new ProductApi()
                {
                    DeliveryDate = item.DeliveryDate,
                    ProductDescription = item.ProductDescription,
                    ProductQuantity = item.ProductQuantity,
                    UnitaryPrice = item.UnitaryPrice,
                    Total = Math.Round(item.UnitaryPrice * item.ProductQuantity, 2)
                });
            }

            return products;
        }
    }
}
