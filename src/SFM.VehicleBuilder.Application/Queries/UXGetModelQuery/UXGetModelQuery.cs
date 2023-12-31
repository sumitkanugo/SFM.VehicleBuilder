﻿using MediatR;
using SFM.VehicleBuilder.Domain.Correlation;
using SFM.VehicleBuilder.Domain.Models;
using System.Collections.Generic;

namespace SFM.VehicleBuilder.Application.Queries.UXGetModelQuery
{
    public class UXGetModelQuery : SecureQueryBase<IEnumerable<Model>>
    {
        public UXGetModelQuery(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the Division.
        /// </summary>
        public int Division { get; set; }
    }
}