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

Aşağıda kullanıcı arayüzüne ait sayfa görüntüleri kategorilere ayrılmış şekilde listelenmiştir.

### Ana Sayfa

<img width="1890" height="852" alt="Image" src="https://github.com/user-attachments/assets/921801d7-1022-419a-aba4-b8ecb67673a8" />
<img width="1878" height="873" alt="Image" src="https://github.com/user-attachments/assets/85e9d5a8-71fa-40f1-9575-625abd558c10" />
<img width="1882" height="877" alt="Image" src="https://github.com/user-attachments/assets/26be38af-8198-4e13-9c15-664b663c5acf" />
<img width="1886" height="876" alt="Image" src="https://github.com/user-attachments/assets/bdf2b9b4-a811-447f-801c-bd6fad6308a7" />
<img width="1888" height="873" alt="Image" src="https://github.com/user-attachments/assets/b6a2de6a-45cc-4570-acb7-b3824b0e4e72" />

### Admin Panel — Dashboard
<!-- ![Admin Dashboard](wwwroot/screenshots/admin-dashboard.png) -->

### Admin Panel — Ürün Yönetimi
<!-- ![Admin Ürünler](wwwroot/screenshots/admin-products.png) -->
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
