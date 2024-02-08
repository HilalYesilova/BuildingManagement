﻿using BuildingManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Repository.Repository.PaymentRepository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Apartment>> GetApartmentsPaymentsAsync();
    }
}
