using BatchApp.Models;
using BatchApp.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace BatchApp.Controllers
{
//    [Authorize]
//    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private IBatchRepository _batchRepo;

        public BatchController(IBatchRepository batchRepo)
        {
            _batchRepo = batchRepo;
        }

        //List<BatchModel> batches = new List<BatchModel>();

        //public BatchController()
        //{
        //    batches = new List<BatchModel>();
        //    for(int i=1;i<=10;i++)
        //    {
        //        batches.Add(new BatchModel());
        //    }
        //}
        //[HttpGet]
        //public IEnumerable<BatchModel> Get()
        //{ 
        //    return batches;
        //}

        ///// <summary>
        ///// Get List of Employees
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<BatchModel>))]
        //[ProducesResponseType(400)]
        //public IActionResult GetBatches()
        //{
        //    var ObjList = _batchRepo.GetBatches();//To get the employee list

        //    var ObjDto = new List<BatchModel>();

        //    foreach (var Obj in ObjList)
        //    {
        //        ObjDto.Add(_mapper.Map<BatchModel>(Obj));
        //    }
        //    return Ok(ObjDto);//API call 
        ////}
        //public IActionResult GetBach(String BusinessUnit)
        //{
        //    var CorrelationId = HttpContext.Request.Headers["x-CorrelationId"].ToString();

        //    _batchRepo = SendBatchCore(CorrelationId);

        //    return ViewResult();
        //}

        //private async Task SendBatchCore(string correlationId)
        //{

        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="batchId">Get Details of the Batch</param>
        /// <returns></returns>
        [HttpGet("({batchId:Guid}", Name = "GetBatch")]
        [ProducesResponseType(200, Type = typeof(BatchModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetBatch(Guid batchId)
        {
            var batchObj = _batchRepo.GetBatch(batchId);
            if (batchObj == null)
                return NotFound();

            return Ok(batchObj);
        }
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BatchModel))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult CreateBatch([FromBody] BatchModel batch)
        {
            if (batch == null)
                return BadRequest(ModelState);

            if (_batchRepo.CheckIfBUExists(batch.BusinessUnit))
            {
                ModelState.AddModelError("", "Business Unit Exists.");
                return StatusCode(400, ModelState);
            }
            if (!_batchRepo.CheckACL(batch.ACLs))
            {
                ModelState.AddModelError("", "Business Unit Exists.");
                return StatusCode(400, ModelState);
            }

            if (!_batchRepo.CheckAtribute(batch.Atributes))
            {
                ModelState.AddModelError("", "Business Unit Exists.");
                return StatusCode(400, ModelState);
            }

            if (_batchRepo.CreateBatch(batch))
            {
                return CreatedAtRoute("GetBatch", new { batchId = batch.BatchID }, batch);
            }

            ModelState.AddModelError("", $"Something went wrong while creating Batch {batch}");
            return StatusCode(400, ModelState);
        }


        //[HttpPatch("{batchId:Guid", Name = "UpdateBatch")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult UpdateBatch(Guid basicId, [FromBody] BatchModel basicDto)
        //{
        //    if (basicDto == null || basicId != basicDto.BatchID)
        //    {
        //        return BadRequest(ModelState);//contains all errors
        //    }

        //    var BObj = _mapper.Map<BatchModel>(basicDto);
        //    if (!_batchRepo.UpdateBatch(BObj))
        //    {
        //        ModelState.AddModelError("", $"Something went wrong when updating the record {BObj.BusinessUnit}");
        //        return StatusCode(500, ModelState);
        //    }
        //    return NoContent();
        //}

        //[HttpDelete("{batchId:Guid}", Name = "DeleteBatch")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status409Conflict)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        //public IActionResult DeleteBatch(Guid batchId)
        //{
        //    if (!_batchRepo.CheckIfIdExists(batchId))
        //    {
        //        return NotFound();
        //    }

        //    var BObj = _batchRepo.GetBatch(batchId);
        //    if (!_batchRepo.DeleteBatch(BObj))
        //    {
        //        ModelState.AddModelError("", $"Something went wrong when updating the record{BObj.BusinessUnit}");
        //        return StatusCode(500, ModelState);
        //    }
        //    return NoContent();
        //}



    }
}