﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SFM.VehicleBuilder.Domain.Models
{
    /// <summary>
    ///   A chrome data vehicle CargoItem.
    /// </summary>
    public class WheelBase
    {
        /// <summary>
        ///   Gets or sets a chrome data StyleIds Available.
        /// </summary>
        public int[] StyleIds { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether a chrome data Value.
        /// </summary>
        public string Value { get; set; }
    }
}
