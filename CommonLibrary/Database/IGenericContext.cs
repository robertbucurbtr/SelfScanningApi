using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Database
{
    public interface IGenericContext<T> where T : BaseClass
    {
        IMongoCollection<T> Entities { get; }
    }
}
