using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdAccountGroup
{
    [TestClass]
    public class ReadSingleTest : TestBase
    {
        private IAccountGroupRepository _repository;
        private facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup.AdAccountGroup _model;
        private List<AdAccountGroupFieldsEnum> _fields;

        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup.AdAccountGroup();

            _fields = new List<AdAccountGroupFieldsEnum>
            {
                AdAccountGroupFieldsEnum.AccountGroupId,
                AdAccountGroupFieldsEnum.Name,
                AdAccountGroupFieldsEnum.Status
            };
            
            

            var mock = new Mock<IAccountGroupRepository>();
            mock.Setup(a => a.ReadSingle(InvalidAdAccountGroupId1, _fields))
                .Throws<ArgumentOutOfRangeException>();
            mock.Setup(a => a.ReadSingle(ValidAdAccountGroupId, _fields))
                .Returns(ValidAdAccountGroup);
            _repository = mock.Object;
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantReadSingleWithInvalidAccountGroup()
        {
            _model.ReadSingle(InvalidAdAccountGroupId1, _repository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CantReadSingleWithInvalidRepository()
        {
            _model.ReadSingle(InvalidAdAccountGroupId1, _repository);
        }

        [TestMethod]
        public void CanReadSingle()
        {
            var result = _model.ReadSingle(ValidAdAccountGroupId, _fields, _repository);
            
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsValidData());
        }
    }
}
