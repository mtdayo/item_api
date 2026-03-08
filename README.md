# Item Management API

ASP.NET Core Web API + Entity Framework Core を使用した
シンプルな **アイテム管理API** です。

実務を想定した以下の構成を採用しています。

* Clean Architecture 風構成
* Repository Pattern
* Service Layer
* DTO
* AutoMapper
* JWT Authentication
* Search API
* Soft Delete
* Swagger API Documentation

---

# 設計方針

本APIは以下の設計を意識して構築しています。

- Controllerはビジネスロジックを持たない
- Service層にビジネスロジックを配置
- Repository層でデータアクセスを管理
- DTOでAPIレスポンスを分離

---

# 技術スタック

* **.NET 8**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **AutoMapper**
* **JWT Authentication**
* **Swagger (OpenAPI)**

---

# プロジェクト構成

item_api
 ├ Controllers
 ├ Services
 ├ Repositories
 ├ DTOs
 ├ Mappings
 ├ Models
 ├ Data
 ├ Middleware
 ├ Dockerfile
 ├ docker-compose.yml
 └ Program.cs

---

# セットアップ

## 1. リポジトリ取得

```
git clone https://github.com/mtdayo/item_api.git
cd item_api
```

---

## 2. 依存関係インストール

```
dotnet restore
```

---

## 3. データベース作成

```
dotnet ef database update
```

---

## 4. アプリ起動

```
dotnet run
```

---

# Swagger

起動後ブラウザで以下にアクセス

```
http://localhost:5082/swagger
```

でAPI確認できます。

---

# API一覧

## Item API

アイテム管理用のCRUD APIです。

| Method | Endpoint         | 説明   |
| ------ | ---------------- | ---- |
| GET    | /api/item/{id}   | ID取得 |
| GET    | /api/item/search | 名前検索 |
| POST   | /api/item        | 新規作成 |
| PUT    | /api/item/{id}   | 更新   |
| DELETE | /api/item/{id}   | 削除   |

---

## Auth API

JWTトークンを発行する認証APIです。

| Method | Endpoint        | 説明      |
| ------ | --------------- | ------- |
| POST   | /api/auth/login | JWTログイン |

---

# 検索API

```
GET /api/item/search?name=pen
```

レスポンス

```
[
  {
    "id": 1,
    "name": "pen"
  }
]
```

---

# Soft Delete

削除は **物理削除ではなく論理削除（Soft Delete）** を採用しています。

```
DELETE /api/item/{id}
```

内部処理

```
IsDeleted = true
```

---

# 認証

ログイン

```
POST /api/auth/login
```

```
{
  "username": "admin",
  "password": "password"
}
```

レスポンス

```
{
  "token": "JWT_TOKEN"
}
```

以降のAPI

```
Authorization: Bearer JWT_TOKEN
```

---

# 今後の改善

* Pagination
* Global Exception Handling
* Logging
* Unit Test
* Docker
* CI/CD

---

# License

MIT
