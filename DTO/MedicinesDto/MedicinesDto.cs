﻿namespace MedicalAppBackend.DTO.MedicinesDto
{
    public class MedicinesDto
    {
        public string? MedicineName { get; set; }

        public string? Manufacturer { get; set; } 

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public int? Quantity { get; set; }

        public DateTime ExpDate { get; set; }

        public string? ImageUrl { get; set; }

        public int? Status { get; set; }
    }
}
