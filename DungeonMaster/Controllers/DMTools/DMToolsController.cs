using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DungeonMaster.WebApi.ViewModels.Tools;
using DungeonMaster.WebApi.ViewModels.Tools.CalculateDamage;

namespace DungeonMaster.WebApi.Controllers.DMTools
{
    [Produces("application/json")]
    [Route("api/DMTools/")]
    public class DMToolsController : Controller
    {
        [Route("Roll/d/{dieSize:int}")]
        public int Roll(DieSizeEnum dieSize)
        {
            if (!Enum.IsDefined(typeof(DieSizeEnum), dieSize))
            {
                throw new DataMisalignedException("Unexpected Die Size. Please use Standard Die sizes.");
            }
            return new Random().Next(1, (int)dieSize + 1);
        }

        [Route("CalculateDamage")]
        public float CalculateDamage(CalculateDamageRequestVM request)
        {
            if (!Enum.IsDefined(typeof(DieSizeEnum), request.DieSize))
            {
                throw new DataMisalignedException("Unexpected Die Size. Please use Standard Die sizes.");
            }
            if (request.IsCritical)
            {
                return (request.DieCount * (int)request.DieSize) + request.AdditionalModifiers;
            }
            return (request.DieCount * new Random().Next(1, (int)request.DieSize) + 1) + request.AdditionalModifiers;
        }
    }
    
}