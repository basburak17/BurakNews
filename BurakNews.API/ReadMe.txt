1) İlk olarak bütün katmanları oluşturdum.
2) Core katmanını yazmaya başladım.
3) Core katmanında Entity, IRepository, IUnitOfWork ve IService yapılarımı oluşturdum.
4) Entity'lerimi oluşturmadan önce bir IEntity oluşturdum. Entity lerim bunu implemente edecek. IEntity içinde Id, CreatedDate, ModifiedDate tutuyorum.
5) Microsoft.Identity kütüphanesini kullanacağım için AppUser, AppRole tablolarımı oluşturdum.
6) IGenericRepository interface'ini oluşturdum ve metot işlemlerimi yaptım.
7) IService interface'ini oluşturdum ve metot işlemlerimi yaptım.
8) IUnitOfWork interface'ini oluşturdum. Db de yapacağım işlemleri tek bir transaction üzerinden yönetmek için kullanacağım.
9) Repository katmanını yazmaya başladım.
10) DbContext sınıfımı oluşturdum ve gerekli ayarlamaları yaptım.
11) Configurations klasörümü oluşturup entity'lerim için istediğim attribute leri ekledim. (Fluent API)
12) Seed Data lar oluşturarak DB ayağa kalkmadan önce birkaç datamın olması için entity'lerim için categoryseed ve newseed sınıflarımı yazdım.
13) Repository katmanında, Core katmanında yazdığım IGenericRepository implementasyonunu GenericRepository class'ıma yaptım ve crud işlemlerimi yazdım.
14) Repository katmanında, Core katmanında yazdığım IUnitOfWork implementasyonunu UnitOfWork class'ıma yaptım ve commit islemlerimi yazdım.
15) API ve Web tarafında program.cs class'ımın içine AddScoped olarak interface ve classlarımı ekledim. (Service, GenericRepo vs.)
16) Migration yapıldı ve DB yansıtıldı.
17) Service katmanımı yazdım. Business kodlarımın olduğu kısımdır.
18) Core katmanında DTO larımı oluşturdum.
19) AutoMapper kullanarak Service katmanında Mapping işlemi yaptım. DTO larım ile Entity lerimi birbirine otomatik mapledim.
20) API tarafında Haberlerim için API controller oluşturup bazı Api işlemleri yaptım.
21) Core katmanında New(Haber) entity'im için Repo ve Service oluşturdum.
22) API tarafında CustomBaseController oluşturdum ve diğer controller'larım bunu implemente edecek içindeki metodu kullanıyorum.
23) NewsController oluşturdum ve belirli endpointler yazdım.
24) CategoriesController oluşturdum ve belirli endpointler yazdım.
25) Fluent Validation paketini yükledim ve Service katmanımda Dto larım için validatorler yazdım.
26) API tarafında kullanıcıya client side veya server side error mesajlar dönmek için API katmanında CustomExceptionHandler yazdım.
27) ClientSideException class'ımı API ve WEB katmanlarımda kullanabileceğimden dolayı Service katmanımda oluşturdum.
28) Filter Module vs. class larımı oluşturdum ve kodladım.
29) AutoFac ile DI işlemlerimi gerçekleştirdim.