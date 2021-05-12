﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.Model.Models
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }
        
        [Required]
        public Guid ImeiNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
