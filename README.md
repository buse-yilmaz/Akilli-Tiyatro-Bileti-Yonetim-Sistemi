# 🎭 Akıllı Tiyatro Bileti Yönetim Sistemi

***Proje Amacı***

Tiyatro bilet ve rezervasyon süreçlerini dijital ortama taşıyarak kullanıcı dostu bir yönetim sistemi geliştirmektir. Şehir bazlı oyun listeleme, rezervasyon ve yönetici paneli ile süreçlerin daha hızlı ve verimli işlemesi hedeflenmektedir.Tiyatro bileti satışı ve yönetimini kolaylaştırmak amacıyla geliştirilmiş, MySQL veritabanı destekli masaüstü uygulamasıdır.

## Özellikler

### Kullanıcı Tarafı
- Kullanıcı kayıt ve giriş sistemi
- Şehir, ilçe ve tarihe göre oyun filtreleme
- Interaktif koltuk seçim ekranı
- Ödeme ekranı
- Rezervasyon oluşturma

### Yönetici Tarafı
- Admin girişi
- Oyun ekleme, güncelleme ve silme
- Seans ekleme, güncelleme ve silme
- Kullanıcı yönetimi
- Rezervasyon takibi

## Kullanılan Teknolojiler

- **C# / Windows Forms** — Masaüstü uygulama geliştirme
- **MySQL** — Veritabanı yönetimi
- **MySql.Data (NuGet)** — MySQL bağlantısı
- **Visual Studio 2022** — Geliştirme ortamı

## Veritabanı Yapısı

| Tablo | Açıklama |
|-------|----------|
| `kullanicilar` | Kayıtlı kullanıcı bilgileri |
| `oyunlar` | Tiyatro oyunları |
| `salonlar` | Tiyatro salonları |
| `sehirler` | Şehir bilgileri |
| `ilceler` | İlçe bilgileri |
| `seanslar` | Oyun seans bilgileri |
| `rezervasyonlar` | Bilet rezervasyonları |

## Ekranlar

***Anasayfa Ekranı***

<img width="1106" height="705" alt="image" src="https://github.com/user-attachments/assets/de8bd6c9-5cae-473c-955f-2d1723146b09" />


***Giriş Yap Ekranı***
 
 <img width="777" height="498" alt="image" src="https://github.com/user-attachments/assets/0cf946fc-d554-416f-be92-7c48942bd5c8" />


***Üye Ol Ekranı***

<img width="795" height="599" alt="image" src="https://github.com/user-attachments/assets/693dc5d4-f8b3-47b0-8c55-5832f4627c13" />


***Yöenetici Giriş Ekranı***

<img width="849" height="546" alt="image" src="https://github.com/user-attachments/assets/94639712-ae19-4868-802d-41b8294987fa" />


***Yöentici Paneli***

<img width="1168" height="799" alt="image" src="https://github.com/user-attachments/assets/3d03cf72-1071-47d1-99a0-03c4a4856532" />


***Oyunlar Ekranı***

<img width="1122" height="743" alt="image" src="https://github.com/user-attachments/assets/8ad617fc-8cf7-4ac0-8562-7384c1d1b369" />


***Koltuk Seçim Ekranı***

<img width="750" height="493" alt="image" src="https://github.com/user-attachments/assets/8b1a30fb-2395-4174-ad68-9aa3bcef3ca2" />

***Ödeme Ekranı***

<img width="470" height="497" alt="image" src="https://github.com/user-attachments/assets/bad0e3ba-88d0-4e00-8444-055c3a46adde" />



## Grup Üyeleri

| İsim | Numara |
|------|-----|
| Sevim Çıra | 032390053 |
| Neslihan Özdemir | 032390069 |
| Buse Yılmaz | 032390024 |
| Semanur Erdoğan | 032390064 |

##  Kurulum

### Gereksinimler
- Visual Studio 2022
- .NET Framework 4.7.2+
- MySQL Server
- MySQL Workbench (opsiyonel)

### Adımlar

1. Repoyu klonla:
```bash
   git clone https://github.com/buse-yilmaz/Akilli-Tiyatro-Bileti-Yonetim-Sistemi.git
```

2. MySQL'de veritabanını oluştur:
```sql
   CREATE DATABASE TiyatroDB;
```
   Sonra `TiyatroDB.sql` dosyasını içe aktar.

3. `VeriTabani.cs` dosyasında bağlantı bilgilerini güncelle:
```csharp
   private static string connectionString = "Server=localhost;Database=TiyatroDB;Uid=root;Pwd=ŞIFRE;";
```

4. Visual Studio'da projeyi aç ve çalıştır.

