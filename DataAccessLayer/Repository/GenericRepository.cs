using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            //"new" anahtar kelimesiyle birlikte bir "Context" nesnesi oluşturulur ve daha sonra bu nesnenin işlemi tamamlandığında bellekten serbest bırakılmasını sağlamak için elle temizleme yapılması gerekebilir.
            //Context c1 = new Context();// 

            //"using" ifadesi kullanılır. Bu ifade, "Context" nesnesinin otomatik olarak kaynağını temizlemesini sağlar. "using" bloğu tamamlandığında veya bir istisna oluştuğunda, nesnenin Dispose() metodu çağrılır ve kaynak serbest bırakılır. Böylece, "using" bloğu dışına çıkıldığında "Context" nesnesi bellekten otomatik olarak serbest bırakılır.
            // "using" ifadesi kullanıldığında, kaynakların temizlenmesiyle ilgili sorumluluk daha iyi yönetilir ve bellek sızıntıları önlenmiş olur. Bu, kodun daha temiz ve daha güvenilir olmasını sağlar.
            using var c = new Context(); 
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();

            //Bu metod aracıgı ile istediğim şarta göre listeleme işlemi gerçekleşir
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id) //void türünde olmadığı için ---> geriye return ifadesini bekler
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();     
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);   
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();    
        }
    }
}
