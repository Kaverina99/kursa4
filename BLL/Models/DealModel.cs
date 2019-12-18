﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DealModel
    {
        public int Id_Deal { get; set; }
        public DateTime Deal_Date { get; set; }
        public string Deal_Form_of_Payment { get; set; }
        public string Deal_Mortgage_Period { get; set; }
        public string Deal_Monthly_Payout { get; set; }
        public decimal Deal_Total_Cost { get; set; }
        public int Deal_Seller_FK { get; set; }
        public int? Deal_Customer_FK { get; set; }
        public int Deal_Property_FK { get; set; }
        public int Deal_Agent_FK { get; set; }
        public decimal Deal_AgentShare_Cost { get; set; }
        public DealModel() { }
        public DealModel(Deal D)
        {
            Id_Deal = D.Id_Deal;
            Deal_Date = D.Deal_Date;
            Deal_Form_of_Payment = D.Deal_Form_of_Payment;
            Deal_Mortgage_Period = D.Deal_Mortgage_Period;
            Deal_Monthly_Payout = D.Deal_Monthly_Payout;
            Deal_Total_Cost = D.Deal_Total_Cost;
            Deal_Seller_FK = D.Deal_Seller_FK;
            Deal_Customer_FK = D.Deal_Customer_FK;
            Deal_Property_FK = D.Deal_Property_FK;
            Deal_Agent_FK = D.Deal_Agent_FK;
            Deal_AgentShare_Cost = D.Deal_AgentShare_Cost;
        }
    }
}
