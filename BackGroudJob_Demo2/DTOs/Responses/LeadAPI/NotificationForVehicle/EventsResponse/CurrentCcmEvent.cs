﻿using BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.AppointmentsResponse;

namespace BackGroudJob_Demo2.DTOs.Responses.LeadAPI.NotificationForVehicle.EventsResponse
{
    public class CurrentCcmEvent
    {
        public string CcmEventIdentifier { get; set; }
        public CcmDemand CcmDemand { get; set; }
    }
}