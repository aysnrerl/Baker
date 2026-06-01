# 🍞 Baker — Dinamik Fırın Web Uygulaması

> Modern, dinamik ve tamamen yönetilebilir fırın web sitesi.  
> ASP.NET Core Web API + MVC ve SQL Server ile geliştirilmiştir.

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-6.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework%20Core-6.0-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-563D7C?style=flat-square&logo=bootstrap&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=black)

---

## 📖 Proje Hakkında

**Baker**, bir fırın işletmesinin tüm dijital ihtiyaçlarını tek bir platformda karşılamak amacıyla geliştirilmiş, **2 katmanlı (Web API + MVC)** mimariye sahip tam kapsamlı bir web uygulamasıdır.

**Web API katmanı** tüm iş mantığını ve veri erişimini yönetirken, **MVC katmanı** HttpClient aracılığıyla bu API'yi tüketerek kullanıcıya dinamik ve modern bir arayüz sunar. 12 tablodan oluşan ilişkisel veritabanı yapısı sayesinde işletmenin ürünlerinden şef kadrosuna, galerisinden abone listesine kadar her modül anlık olarak yönetilebilmektedir.

---

## 🏗️ Mimari ve Teknik Detaylar

| Kategori | Teknoloji | Kullanım Amacı |
|---|---|---|
| **Backend API** | ASP.NET Core 6.0 Web API | RESTful API katmanı |
| **Frontend** | ASP.NET Core 6.0 MVC | Kullanıcı arayüzü katmanı |
| **ORM** | Entity Framework Core 6.0 | Veritabanı erişim katmanı |
| **Veritabanı** | SQL Server | İlişkisel veri depolama |
| **Veri Transferi** | DTO (Data Transfer Objects) | Katmanlar arası temiz veri akışı |
| **HTTP İletişimi** | HttpClient | MVC → API veri çekme |
| **UI Bileşenleri** | ViewComponent | Modüler ve yeniden kullanılabilir arayüz |
| **API Testi** | Swagger UI | Endpoint dokümantasyonu ve test |
| **Frontend UI** | Bootstrap 5 & JavaScript | Responsive tasarım |

### 🔧 Geliştirme Prensipleri

- **2 Katmanlı Mimari:** Web API ve MVC projeleri birbirinden bağımsız olarak çalışır; API herhangi bir istemci tarafından tüketilebilir.
- **DTO Pattern:** `CreateDto`, `UpdateDto` ve `ResultDto` ayrımıyla katmanlar arası veri güvenliği sağlanmıştır. Gereksiz veri ifşası önlenmiştir.
- **HttpClient Entegrasyonu:** MVC katmanı, API'deki tüm CRUD işlemlerini HttpClient servis sınıfları aracılığıyla gerçekleştirir.
- **ViewComponent Mimarisi:** Navbar, footer, ürün listesi, istatistikler gibi her UI bileşeni ayrı `ViewComponent` olarak geliştirilmiş; kod tekrarı engellenmiştir.
- **Swagger UI:** Geliştirme sürecinde tüm endpoint'ler Swagger üzerinden test edilmiş ve dokümante edilmiştir.

---

## ✨ Özellikler

### 🌐 Ana Site (Web UI)

- **Hero Section** — Etkileyici ana görsel ve sloganlar
- **Hakkımızda** — İşletme tanıtımı, misyon ve vizyon
- **Hizmetlerimiz** — Sunulan tüm hizmetlerin dinamik listesi
- **Ürünler** — Kategorilere ayrılmış, veritabanından gelen dinamik ürün kataloğu
- **Şeflerimiz** — Şef kadrosunun fotoğraflı tanıtım kartları
- **Galeri** — İşletmeye ait görsel showcase
- **Referanslar** — Müşteri referansları ve geri bildirimleri
- **İstatistikler** — Ürün çeşidi, müşteri sayısı, deneyim yılı
- **Adres & İletişim** — Harita entegrasyonu ve iletişim formu
- **Abone Ol** — E-bülten abonelik sistemi
- **Responsive Tasarım** — Mobil, tablet ve masaüstünde tam uyumluluk

### 🔐 Admin Paneli

- **Dashboard** — Anlık istatistikler ve modüllere hızlı erişim
- **Ürün Yönetimi** — Ürün ekleme, düzenleme, silme (CRUD)
- **Kategori Yönetimi** — Ürün kategorilerini yönetme
- **Şef Yönetimi** — Şef profili oluşturma ve güncelleme
- **Hizmet Yönetimi** — Sunulan hizmetlerin yönetimi
- **Galeri Yönetimi** — Görsel ekleme ve düzenleme
- **Referans Yönetimi** — Müşteri referanslarını yönetme
- **Mesaj Yönetimi** — Ziyaretçi mesajlarını görüntüleme
- **Abone Yönetimi** — E-bülten abonelerini listeleme
- **Hakkımızda & Adres** — İşletme bilgilerini güncelleme

---

## 🗄️ Veritabanı Yapısı

Proje **12 tablo** içermektedir:

| # | Tablo | Açıklama |
|---|---|---|
| 1 | **Products** | Ürün bilgileri (Ad, Fiyat, Açıklama, Görsel, Kategori) |
| 2 | **Categories** | Ürün kategorileri (Ad, Açıklama, İkon) |
| 3 | **Chefs** | Şef bilgileri (Ad, Ünvan, Fotoğraf, Açıklama) |
| 4 | **Services** | Sunulan hizmetler (Başlık, Açıklama, İkon) |
| 5 | **Gallery** | Galeri görselleri (Başlık, Görsel URL, Açıklama) |
| 6 | **Messages** | Ziyaretçi mesajları (Ad, E-posta, Konu, İçerik, Tarih) |
| 7 | **Subscribers** | E-bülten aboneleri (E-posta, Abonelik Tarihi) |
| 8 | **References** | Müşteri referansları (Ad, Açıklama, Fotoğraf) |
| 9 | **About** | Hakkımızda bilgileri (Başlık, Açıklama, Görsel) |
| 10 | **AddressInfo** | Adres ve iletişim bilgileri (Adres, Telefon, E-posta, Harita) |
| 11 | **Features** | Öne çıkan özellikler / avantajlar |
| 12 | **Statistics** | İstatistik bilgileri (Ürün sayısı, Müşteri sayısı vb.) |

---

## 📁 Proje Yapısı

```
Baker/
├── Baker.WebApi/
│   ├── Controllers/
│   │   ├── ProductController.cs
│   │   ├── CategoryController.cs
│   │   ├── ChefController.cs
│   │   ├── ServiceController.cs
│   │   ├── GalleryController.cs
│   │   ├── MessageController.cs
│   │   ├── SubscriberController.cs
│   │   ├── ReferenceController.cs
│   │   ├── AboutController.cs
│   │   ├── AddressInfoController.cs
│   │   ├── FeatureController.cs
│   │   └── StatisticController.cs
│   ├── Entities/              # Veritabanı entity modelleri
│   ├── Dto/
│   │   ├── CreateDto/         # Oluşturma DTO'ları
│   │   ├── UpdateDto/         # Güncelleme DTO'ları
│   │   └── ResultDto/         # Listeleme / okuma DTO'ları
│   ├── Context/               # DbContext (EF Core)
│   └── Migrations/            # Veritabanı migration dosyaları
│
├── Baker.WebUI/
│   ├── Controllers/
│   │   ├── DefaultController.cs       # Ana site controller
│   │   └── Admin/                     # Admin panel controller'ları
│   ├── Services/                      # HttpClient servis sınıfları
│   ├── Views/
│   │   ├── Default/                   # Ana site view'ları
│   │   ├── Admin/                     # Admin panel view'ları
│   │   └── Shared/
│   │       └── Components/            # ViewComponent şablonları
│   ├── ViewComponents/                # ViewComponent sınıfları
│   └── wwwroot/                       # Statik dosyalar (CSS, JS, Görseller)
│
└── README.md
```
## 👨‍💻 Kullanıcı Paneli

Ana sayfa, ziyaretçileri karşılayan hero bölümü, öne çıkan ürünler ve hizmetlerle birlikte işletmenin genel bir vitrini olarak tasarlanmıştır. Tüm içerikler veritabanından dinamik olarak çekilmekte olup admin panelinden anlık güncellenebilmektedir. Responsive yapısı sayesinde mobil, tablet ve masaüstü cihazlarda kusursuz görüntüleme sunar.

### Ana Sayfa

<img width="1890" height="852" alt="Image" src="https://github.com/user-attachments/assets/921801d7-1022-419a-aba4-b8ecb67673a8" />
<img width="1887" height="876" alt="Image" src="https://github.com/user-attachments/assets/85fcb3c5-cd47-48a4-97bb-4fc51843ecd6" />
<img width="1878" height="873" alt="Image" src="https://github.com/user-attachments/assets/85e9d5a8-71fa-40f1-9575-625abd558c10" />
<img width="1882" height="877" alt="Image" src="https://github.com/user-attachments/assets/26be38af-8198-4e13-9c15-664b663c5acf" />
<img width="1886" height="876" alt="Image" src="https://github.com/user-attachments/assets/bdf2b9b4-a811-447f-801c-bd6fad6308a7" />
<img width="1888" height="873" alt="Image" src="https://github.com/user-attachments/assets/b6a2de6a-45cc-4570-acb7-b3824b0e4e72" />
<img width="1887" height="873" alt="Image" src="https://github.com/user-attachments/assets/f8cfd6bb-85a9-45d8-8c2c-168509b55e9c" />
<img width="1877" height="882" alt="Image" src="https://github.com/user-attachments/assets/070ce8b5-ad4e-4a97-9110-7fc678a3696b" />

### 🔐 Admin Panel — Dashboard
Dashboard, işletmenin genel durumunu tek bakışta sunmak amacıyla tasarlanmış istatistik odaklı bir yönetim ekranıdır. Toplam ürün sayısı, kayıtlı şef sayısı, gelen mesajlar ve aktif aboneler gibi veriler anlık olarak görüntülenmektedir. Tüm yönetim modüllerine sol menü aracılığıyla hızlıca erişilebilir.

<img width="1845" height="884" alt="Image" src="https://github.com/user-attachments/assets/47474661-daef-481d-bb28-5a4a2909ee42" />

### 📦 Admin Panel — Ürün Yönetimi
Ürün yönetimi modülü, fırına ait tüm ürünlerin listelendiği, eklendiği, düzenlendiği ve silinebildiği tam kapsamlı bir CRUD ekranıdır. Her ürün için ad, fiyat, açıklama, görsel URL ve kategori bilgisi ayrı ayrı tanımlanabilmektedir. Kategori bazlı filtreleme özelliği sayesinde çok sayıda ürün arasında hızlı yönetim imkânı sunulmaktadır.

<img width="1388" height="794" alt="Image" src="https://github.com/user-attachments/assets/2711ddd4-d935-4343-ae1c-a1f87efa8987" />

<img width="1475" height="653" alt="Image" src="https://github.com/user-attachments/assets/6ca7ad8b-8ab3-4efa-b56d-e57bb86846b0" />

### 🗂️ Admin Panel — Kategori Yönetimi
Kategori yönetimi ekranı, ürünlerin gruplandırıldığı kategorilerin oluşturulmasını ve düzenlenmesini sağlamaktadır. Her kategori için ad, açıklama ve ikon bilgisi tanımlanabilmekte; ürün yönetim ekranında bu kategoriler dinamik olarak listelenmektedir. Kategori silme işleminde ilişkili ürünler etkilenmeyecek şekilde kontrol mekanizması kurgulanmıştır.

<img width="1475" height="611" alt="Image" src="https://github.com/user-attachments/assets/8723beb7-0221-440c-9c29-5809d030ed68" />

<img width="1474" height="471" alt="Image" src="https://github.com/user-attachments/assets/6ea7d55c-4637-4319-825e-3ff750e6c25e" />

### 👨‍🍳 Admin Panel — Şef Yönetimi
Şef yönetimi modülü, işletmenin mutfak ekibinin profillerinin oluşturulup yönetildiği ekrandır. Her şef için ad, ünvan, fotoğraf URL ve kısa biyografi bilgisi girilebilmektedir. Ana sitede şefler bölümünde görüntülenen kartlar doğrudan bu modülden beslenmektedir.

<img width="1475" height="606" alt="Image" src="https://github.com/user-attachments/assets/21f79042-01be-4ab2-8b29-6f6b0b64ca31" />

<img width="1415" height="419" alt="Image" src="https://github.com/user-attachments/assets/f4ebbff5-54b8-4d15-9202-e1ac1cf52e53" />

### 🛠️ Admin Panel — Hizmet Yönetimi
Hizmet yönetimi ekranı, işletmenin sunduğu özel sipariş, catering, teslimat gibi hizmetlerin dinamik olarak yönetilmesini sağlamaktadır. Her hizmet için başlık, açıklama ve ikon tanımlanabilmekte; ana sayfada hizmetler bölümü bu verilerle otomatik olarak güncellenmektedir. Yeni hizmet eklemek veya mevcut olanı kaldırmak için herhangi bir kod değişikliği gerekmemektedir.

<img width="1483" height="578" alt="Image" src="https://github.com/user-attachments/assets/7f684ff0-00da-4650-b696-94cd8d42e1e0" />

<img width="1470" height="593" alt="Image" src="https://github.com/user-attachments/assets/06ae8878-e4b5-486b-92d9-cdad197dbbeb" />

### 🖼️ Admin Panel — Galeri Yönetimi
Galeri yönetimi modülü, ana sitede sergilenen fotoğrafların eklenip düzenlenebildiği görsel yönetim ekranıdır. Her görsel için başlık, açıklama ve görsel URL bilgisi tanımlanabilmektedir. Ana sitedeki galeri bölümü tamamen bu modülden beslenmekte olup yeni görsel eklemek yalnızca birkaç tıklama gerektirmektedir.

<img width="1473" height="785" alt="Image" src="https://github.com/user-attachments/assets/81dbb5a6-68a2-42fa-8bbe-d1142add2161" />

<img width="1473" height="437" alt="Image" src="https://github.com/user-attachments/assets/18dbfad8-320f-477d-8bfe-90c5ef925e30" />

### 💬 Admin Panel — Referans Yönetimi
Referans yönetimi ekranı, müşteri referanslarının ve geri bildirimlerinin yönetildiği modüldür. Her referans için müşteri adı, açıklama ve fotoğraf bilgisi girilebilmektedir. Ana sitedeki referanslar bölümü bu modülden dinamik olarak beslenmekte, içerikler anlık güncellenebilmektedir.

<img width="1480" height="587" alt="Image" src="https://github.com/user-attachments/assets/951b0710-4658-4f07-a1b7-2bee99d64259" />

<img width="1478" height="713" alt="Image" src="https://github.com/user-attachments/assets/a96a0112-51c7-40da-861a-0f5d6faedeef" />

### 📬 Admin Panel — Mesaj Yönetimi
Mesaj yönetimi ekranı, ana sitedeki iletişim formu aracılığıyla ziyaretçilerin gönderdiği tüm mesajların listelendiği ve görüntülendiği modüldür. Her mesaj için gönderen adı, e-posta adresi, konu ve içerik bilgileri görüntülenebilmektedir. Mesajlar okundu/okunmadı durumuna göre takip edilebilmekte; gerektiğinde silinebilmektedir.

<img width="1467" height="793" alt="Image" src="https://github.com/user-attachments/assets/755c3337-e8f5-4504-8d77-4f11435c5a76" />

### 📧 Admin Panel — Abone Yönetimi
Abone yönetimi modülü, ana sayfadaki e-bülten formu aracılığıyla kayıt olan tüm abonelerin listelendiği ekrandır. Her abone için e-posta adresi ve kayıt tarihi görüntülenmektedir. Liste üzerinden aboneler takip edilebilmekte ve gerektiğinde sistemden çıkarılabilmektedir.

<img width="1475" height="795" alt="Image" src="https://github.com/user-attachments/assets/23bba21b-be0f-441f-873a-5097c42f536e" />

### 🏢 Admin Panel — Hakkımızda & Adres Bilgisi 

Hakkımızda ve adres bilgisi modülleri, işletmenin kimlik ve iletişim bilgilerinin dinamik olarak yönetildiği ekranlardır. Hakkımızda bölümünde başlık, açıklama ve görsel güncellenebilirken; adres bilgisi ekranında telefon, e-posta, adres ve harita URL'i düzenlenebilmektedir. Bu sayede herhangi bir kod değişikliği yapmadan işletme bilgileri anlık olarak güncellenebilmektedir.

<img width="1480" height="363" alt="Image" src="https://github.com/user-attachments/assets/f313a66c-9338-4e92-b6f7-49a24fac8ae9" />

<img width="1475" height="351" alt="Image" src="https://github.com/user-attachments/assets/a5690366-2bf3-400e-bf06-d5e354359690" />

---

## 📡 API Endpoints

### Products
```
GET    /api/product          # Tüm ürünleri listele
GET    /api/product/{id}     # Belirli ürünü getir
POST   /api/product          # Yeni ürün ekle
PUT    /api/product          # Ürün güncelle
DELETE /api/product/{id}     # Ürün sil
```

### Categories
```
GET    /api/category
GET    /api/category/{id}
POST   /api/category
PUT    /api/category
DELETE /api/category/{id}
```

> Diğer tüm modüller (Chef, Service, Gallery, Message, Subscriber, Reference, About, AddressInfo) aynı CRUD yapısını takip etmektedir.

---

## 🚀 Kurulum

### Gereksinimler

- .NET 6.0 SDK veya üzeri
- SQL Server (LocalDB, Express veya Full)
- Visual Studio 2022 / VS Code / Rider
- Git

### Adım 1: Repository'yi Klonlayın

```bash
git clone https://github.com/kullaniciadi/Baker.git
cd Baker
```

### Adım 2: Veritabanı Bağlantısını Yapılandırın

`Baker.WebApi/appsettings.json` dosyasını açın ve connection string'i kendi SQL Server bilgilerinizle güncelleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BakerDb;Trusted_Connection=True;"
  }
}
```

### Adım 3: Veritabanını Oluşturun

```bash
cd Baker.WebApi
dotnet ef database update
```

### Adım 4: API'yi Başlatın

```bash
cd Baker.WebApi
dotnet run
# API: https://localhost:7283
# Swagger: https://localhost:7283/swagger
```

### Adım 5: WebUI'yi Başlatın

```bash
cd Baker.WebUI
dotnet run
# WebUI: https://localhost:7122
```

### Adım 6: Her İki Projeyi Birlikte Çalıştırma (Önerilen)

Visual Studio'da:
1. Solution dosyasına sağ tıklayın → **Properties**
2. **Multiple startup projects** seçin
3. Her iki projeyi de **Start** olarak işaretleyin
4. **F5** ile başlatın

---



---

## 🙏 Teşekkürler

Bu projenin geliştirilme sürecinde bilgi, sabır ve rehberlikleriyle her zaman yanımda olan değerli hocalarıma sonsuz teşekkürlerimi sunarım:

- [Buse Nur Demirbaş](https://www.linkedin.com/in/buse-nur-demirba%C5%9F-8728321bb/) — Destek ve mentörlük için
- [Murat Yücedağ](https://www.linkedin.com/in/muratyucedag/) — Yol gösterici eğitim ve rehberlik için
- [AkademiQ.Ai](https://www.linkedin.com/company/akademiq-ai/) — Bu kaliteli eğitim ortamını sağladığı için

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!

#AspNetCore #WebAPI #MVC #EntityFramework #SQLServer #Bootstrap #CSharp #DotNet6 #BakeryWebApp
