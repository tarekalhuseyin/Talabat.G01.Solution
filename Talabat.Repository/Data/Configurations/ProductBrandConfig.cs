﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites;

namespace Talabat.Repository.Data.Configurations
{
	internal class ProductBrandConfig : IEntityTypeConfiguration<ProductBrand>
	{
		public void Configure( EntityTypeBuilder<ProductBrand> builder)
		{
			builder.Property(B => B.Name).IsRequired();
		}
	}
}
