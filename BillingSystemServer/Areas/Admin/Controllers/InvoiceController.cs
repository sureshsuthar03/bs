using BillingSystemServer.ValidationFilter;
using BusinessAccessLayer.Services.Interface;
using BussinessAccessLayer.Utils;
using CommanLayer.Messages;
using EntitiesLayer.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Net;

namespace BillingSystemServer.Areas.Admin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        private const string V = "{id:long}";
        public readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;   
        }
        [HttpPost("Create")]
        [ValidationModel]
        public async Task<IActionResult> Create(InvoiceDTO invoiceDetails)
        {
            await _invoiceService.Create(invoiceDetails);
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, ResponseMsg.Create);
        }

        [HttpGet("GetList")]
        [ValidationModel]
        public async Task<IActionResult> GetList()
        {
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, ResponseMsg.DataFatch,
                await _invoiceService.GetList());
        }

        [HttpGet(V)]
        [ValidationModel]
        public async Task<IActionResult> GetById(long id)
        {
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, ResponseMsg.DataFatch,
                await _invoiceService.GetById(id));
        }

        [HttpPut(V)]
        [ValidationModel]
        public async Task<IActionResult> Update(InvoiceDTO invoiceDetails, long id)
        {
            await _invoiceService.Update(invoiceDetails, id);
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, ResponseMsg.Update);
        }

        [HttpDelete(V)]
        [ValidationModel]
        public async Task<IActionResult> Delete(long id)
        {
            await _invoiceService.Delete(id);
            return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, ResponseMsg.Delete);
        }

        [HttpGet("geneate-folder")]
        public async Task<IActionResult> Generate()
        {
            //Directory.CreateDirectory(@"D:\testFolder");
            //using (StreamWriter writer = new(@"D:\testFolder\tesFile.cs"))
            //{
            //    await writer.WriteLineAsync("testFile");
            //}
                return new SuccessResponseUtil<object>().GetSuccessResponse((int)HttpStatusCode.OK, "generated");
        }

        //public void Initialize(GeneratorInitializationContext context)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Execute(GeneratorExecutionContext context)
        //{
        //    var syntaxFactory = context.Compilation.GetSyntaxFactory();

        //// Create a new C# class.
        //var classDeclaration = syntaxFactory.ClassDeclaration("MyClass");

        //// Add a constructor to the class.
        //var constructorDeclaration = syntaxFactory.ConstructorDeclaration();
        //classDeclaration.AddMembers(constructorDeclaration);

        //// Add a method to the class.
        //var methodDeclaration = syntaxFactory.MethodDeclaration("DoSomething");
        //classDeclaration.AddMembers(methodDeclaration);

        //// Add the class to the compilation.
        //context.AddSource("MyClass.cs", classDeclaration.ToFullString());
        //}
    }
}
