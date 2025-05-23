﻿namespace CareFlow.Core.DTOs.Response
{
    public class LocationToReturnDto
    {
        public Guid Id { get; set; }
        public string AddressLine1 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
