using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCardInformationManager : ICreditCardInformationService
    {
        ICreditCardInformationDal _creditCardInformation;
        public CreditCardInformationManager(ICreditCardInformationDal creditCardInformationDal)
        {
            _creditCardInformation = creditCardInformationDal;
        }

        public IResult Add(CreditCardInformation creditCardInformation)
        {
            _creditCardInformation.Add(creditCardInformation);
            return new SuccessResult(Messages.CreditCardInformationAdded);
        }

        public IResult Delete(CreditCardInformation creditCardInformation)
        {
            _creditCardInformation.Delete(creditCardInformation);
            return new SuccessResult(Messages.CreditCardInformationDeleted);
        }

        public IResult Update(CreditCardInformation creditCardInformation)
        {
            _creditCardInformation.Update(creditCardInformation);
            return new SuccessResult(Messages.CreditCardInformationUpdated);
        }
    }
}
