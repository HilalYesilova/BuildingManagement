
# BUILDING MANAGEMENT API
## Site Yönetim Sistemi

Bu proje, bir apartman veya site yönetimi için backend işlemlerini gerçekleştiren bir API'dir. API, dairelerin ve kullanıcıların yönetimini sağlar, ayrıca aidat ve fatura bilgilerini takip eder.
Endpointlere atılacak istekler Postman ortamında işleyiş bazlı gruplandırılmış ve hazırlanmıştır. İstekleri atabilmek adına _BUILDING MANAGEMENT API.postman_collection.json_ dosyasını Postman'e import edebilirsiniz.

## Gereksinimler
* .NET 8 API kullanılarak * oluşturulmuştur.
* RESTful servisler * kullanılmıştır.
* MS SQL Server kullanılarak veritabanı yönetilir.
* EF Core ORM kullanılmıştır.

## Kullanım
### Yönetici İşlemleri
1. #### Kullanıcı Yönetimi
* Yönetici, kullanıcıları (daire sahipleri veya kiracılar) ekleyebilir, güncelleyebilir ve silebilir.
2. #### Daire Yönetimi
* Yönetici, daire bilgilerini girer ve kullanıcıları dairelere atar.
* Dairelere aidat bilgileri toplu olarak veya tek tek atanabilir.
3. #### Fatura Yönetimi
* Yönetici, bina olarak ödenmesi gereken fatura bilgilerini (elektrik, su, doğalgaz) aylık olarak girer.
4. #### Ödeme Takibi
* Yönetici, kullanıcıların yapmış olduğu ödemeleri görüntüler.
* Aylık ve yıllık olarak daire başına borç durumunu görüntüler.
* Düzenli ödeme yapan kullanıcıları görüntüler.


### Kullanıcı İşlemleri
1. #### Giriş
* Kullanıcı, TC No ve telefon numarasıyla giriş yapabilir.
2. #### Aidat ve Fatura Takibi
* Kullanıcı, ödenmiş veya ödenmemiş aidat ve faturaları görebilir.
3. #### Ödeme
* Kullanıcı, aidat veya faturalar için ödeme yapabilir.


## Kurallar
* Her daireye yalnızca bir kullanıcı atanabilir.
* Ödemeler ilgili ayın sonuna kadar yapılmalıdır. Geciken ödemeler için %10 fazla tahsilat yapılır.
* 1 sene boyunca aidatlarını düzenli ödeyen kullanıcılar, bir sonraki sene aidatları %10 daha az öder

## Proje İşleyişi
* Proje ilk çalıştırmada default Yönetici rolünde kullanıcı oluşturulur. 
UserName = _admin@example.com_
Password = _Admin123!_

Projede rol bazlı yetkilendirmeler kullanılmıştır. Bu işlemlerin gerçekleştirilmesinde _Microsoft.AspNetCore.Identity_ kullanılmıştır.

Yönetici, username ve password ile jwt token alarak _Admin_ rolünün erişebileceği endpointler ile işlemler sağlayabilir.

* Proje ilk çalıştırmada Building tablosuna default olarak bir apartman/site bilgileri insert edilir. Bundan sonraki işlemler bu apartman/site içerisine daire atanarak gerçekleşir.

* Yönetici, tek tek daire bilgilerini doldurarak ilgili dairelere kullanıcıların atamasını yapar.

* Yönetici, Kullanım -> Yönetici işlemlerinde belirtilen endpointler dahilinde işlemlerini gerçekleştirebilir.

* Kullanıcı, Telefon numarası ve Tc numarası ile sisteme giriş yaparak Token alır. Bu Token ile _User_ rolünün erişebildiği işlemleri gerçekleştirebilir.

* Kullanıcı, dairesi için başarılı bir şekilde ödeme yaptığı zaman sisteme log kaydı yapılır.

* Projede Versiyonlama ve Loglama kullanılmıştır.

## Veritabanı Yapısı ve İlişkiler

1. ### Building
* Id
* Name
* Address

2. ### Users
* Id
* Name 
* Surname 
* TcNo
* Email
* PhoneNumber

3. ### UserRoles
* UserId
* RoleId

4. ### Apartments
* Id
* BlockInfo
* OccupancyStatus
* ApartmentType
* FloorNumber
* ApartmentNumber
* OwnerOrTenant
* UserId
* BuildingId

5. ### Dues
* Id
* Amount
* IsPaid
* Month
* Year
* ApartmentId

6. ### Bills
* Id
* BuildingId
* Month
* ElectricityAmount
* WaterAmount
* GasAmount

7. ### ApartmentBills
* Id
* ApartmentId
* Month
* Year
* ElectricityAmount
* WaterAmount
* GasAmount
* IsPaid

8. ### Payments
* Id
* PaymentMethod
* PaymentDate
* Amount
* Month
* Year
* UserId
* PaymentTypeId
* ApartmentId
* DuesId
* ApartmentBillId

9. ### PaymentTypes
* Id
* Method


### Tablolar Arası İlişki


![Relationship](https://ibb.co/FHGQG71)


## Başlangıç
1. Proje dosyalarınızı indirin veya klonlayın.
2. _appsettings.Development.json_ dosyasını açın ve veritabanı bağlantı bilgilerinizi güncelleyin.
3. Visual Studio'da projeyi açın ve çalıştırın veya terminalde dotnet run komutunu kullanarak çalıştırın.
4. Projede kullanılan harici kütüphaneleri yükleyin:

* AutoMapper
```bash 
  NuGet\Install-Package AutoMapper -Version 13.0.0
```
* Microsoft.AspNet.Identity.Core
```bash 
  NuGet\Install-Package Microsoft.AspNet.Identity.Core -Version 2.2.4
```
* Microsoft.AspNetCore.Authentication.JwtBearer
```bash 
  NuGet\Install-Package Microsoft.AspNetCore.Authentication.JwtBearer -Version 8.0.1
```
* Microsoft.EntityFrameworkCore.SqlServer 
```bash 
  NuGet\Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.1
```

## Katkıda Bulunma
Herhangi bir sorunla karşılaşırsanız veya bir öneriniz varsa, lütfen bir Issue açın veya bir Pull Request gönderin.


## Lisans

[MIT](https://choosealicense.com/licenses/mit/)

