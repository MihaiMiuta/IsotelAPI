﻿using GraphQL.Types;
using IsotelDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsotelBusinessLayer.GraphQLEntities.Types
{
    public class LandlordType : ObjectGraphType<Landlord>
    {
        public LandlordType()
        {
            Field(x => x.LandlordId).Description("Landlord Identifier");
            Field(x => x.FirstName).Description("Landlord First Name");
            Field(x => x.LastName).Description("Landlord Last Name");
            Field(x => x.Email).Description("Landlord Email");
            Field(x => x.PhoneNumber).Description("Landlord Phone Number");
            Field<ListGraphType<RentType>>("OwnedRents", resolve: context => QueryResolver.GetRentsForLandlord(context.Source.LandlordId, "USD"), description: "List all rents owned by landlord");
        }
    }
}
