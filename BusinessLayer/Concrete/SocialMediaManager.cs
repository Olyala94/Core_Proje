using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialmediaDal;

        public SocialMediaManager(ISocialMediaDal socialmediaDal)
        {
            _socialmediaDal = socialmediaDal;
        }

        public void TAdd(SocialMedia t)
        {
            _socialmediaDal.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            throw new NotImplementedException();
        }

        public SocialMedia TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SocialMedia> TGetList(SocialMedia t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SocialMedia t)
        {
            throw new NotImplementedException();
        }
    }
}
