﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites.Order_Aggregate;

namespace Talabat.Repository.Data.Configurations
{
	internal class OrderItemConfig:IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder) 
		{
			builder.Property(OI => OI.Price).HasColumnType("decimal(18,2");
			builder.OwnsOne(OI => OI.Product, P => P.WithOwner());
		}
	}
}
