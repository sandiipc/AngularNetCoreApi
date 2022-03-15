using System;
using Xunit;
using AngularNetCoreApi;

namespace CoreApi.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var member = new MemberEntity();
            member.MemberId = 1;
            member.FirstName = "Camstar";
            member.LastName = "Admin";
            member.Address = "Server";

        }
    }
}
