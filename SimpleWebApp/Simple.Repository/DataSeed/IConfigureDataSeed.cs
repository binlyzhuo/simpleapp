using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Repository.DataSeed
{
    public interface IConfigureDataSeed
    {
        void ConfigureDataSeed(ModelBuilder builder);
    }
}
