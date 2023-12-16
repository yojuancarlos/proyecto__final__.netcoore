using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdc.Application.Implementation.Implementation.Parameters;
using AirBnbUdC.GUI.Mappers.Parameters;
using AirBnbUdC.GUI.Models;
using AirBnbUdC.GUI.Models.Parameters;
using AirBnbUdC.GUI.Models.ReportModels;
using Microsoft.Reporting.WebForms;

namespace AirBnbUdC.GUI.Controllers.Parameters
{
    public class PropertyOwnerController : Controller
    {

        private IPropertyOwnerApplication app = new PropertyOwnerImplementationApplication();
        PropertyOwnerMapperGUI mapper = new PropertyOwnerMapperGUI();

        // GET: Customer
        public ActionResult Index(string filter = "")
        {
            var list = mapper.MapperT1toT2(app.GetAllRecords(filter));
            return View(list);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel PropertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (PropertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(PropertyOwnerModel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] PropertyOwnerModel PropertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                PropertyOwnerDTO PropertyOwnerDTO = mapper.MapperT2toT1(PropertyOwnerModel);
                app.CreateRecord(PropertyOwnerDTO);
                return RedirectToAction("Index");
            }

            return View(PropertyOwnerModel);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel PropertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (PropertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(PropertyOwnerModel);
        }

        // POST: Customer/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,FamilyName,Email,Cellphone,Photo")] PropertyOwnerModel PropertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                PropertyOwnerDTO PropertyOwnerDTO = mapper.MapperT2toT1(PropertyOwnerModel);
                app.UpdateRecord(PropertyOwnerDTO);
                return RedirectToAction("Index");
            }
            return View(PropertyOwnerModel);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel PropertyOwnerModel = mapper.MapperT1toT2(app.GetRecord(id));
            if (PropertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(PropertyOwnerModel);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            app.DeleteRecord(id);
            return RedirectToAction("Index");

        }
        public ActionResult GenerateReport(string format = "PDF")
        {
            var list = app.GetAllRecords(string.Empty);
            PropertyOwnerMapperGUI PropertyOwnerMapperGUI = new PropertyOwnerMapperGUI();
            List<PropertyOwnerReportModel> recordsList = new List<PropertyOwnerReportModel>();

            foreach (var PropertyOwner in list)
            {
                recordsList.Add(
                    new PropertyOwnerReportModel()
                    {
                        Id = PropertyOwner.Id.ToString(),
                        FirstName = PropertyOwner.FirstName,
                        FamilyName = PropertyOwner.FamilyName,
                        Email = PropertyOwner.Email,
                        Cellphone = PropertyOwner.Cellphone,
                        Photo = PropertyOwner.Photo
                    }
                   );
            }

            string reportPath = Server.MapPath("~/Reports/RdlcFiles/PropertyOwnerReport.rdlc");
            
            LocalReport lr = new LocalReport();

            lr.ReportPath = reportPath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            ReportDataSource datasource = new ReportDataSource("PropertyOwnerDataSet", recordsList);
            lr.DataSources.Add(datasource);


            renderedBytes = lr.Render(
            format,
            string.Empty,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings
            );

            return File(renderedBytes, mimeType);
        }
    }
}
