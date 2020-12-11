using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_API.Models;

namespace Test_API.Data
{
    public interface ITestInterface
    {
        TestModel GetByNumber(int number);

        List<TestModel> GetAllTestModels();

    }
}
