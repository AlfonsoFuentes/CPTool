using AutoMapper.Configuration.Annotations;
using CPtool.ExtensionMethods;
using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.Application.Features.EquipmentTypeSubFeatures.CreateEdit
{

    public class AddEquipmentTypeSub : AddCommand
    {
        public int? EquipmentTypeId { get; set; }



        public string TagLetter { get; set; } = string.Empty;
      

    }

}
