# Bookstore API

- [Bookstore API](#bookstore-api)
  - [Create Book](#create-Book)
    - [Create Book Request](#create-book-request)
    - [Create Book Response](#create-book-response)
  - [Get Book](#get-Book)
    - [Get Book Request](#get-book-request)
    - [Get Book Response](#get-book-response)
  - [Update Book](#update-book)
    - [Update Book Request](#update-book-request)
    - [Update Book Response](#update-book-response)
  - [Delete Book](#delete-book)
    - [Delete Book Request](#delete-book-request)
    - [Delete Book Response](#delete-book-response)

## Create Book

### Create Book Request

```js
POST /api/bookstore
```

```json
{
    "title" : "title1",
    "author" : "Sarwan",
    "description" : "title1 description",
    "publishDate" : "2022-09-17",
    "coverImageUrl" : "cover image url",
    "bookUrl" : "book url"
}
```

### Create Book Response

```js
201 Created
```

```yml
Location: {{host}}/api/bookstore/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "title" : "title1",
    "author" : "Sarwan",
    "description" : "title1 description",
    "publishDate" : "2022-09-17",
    "coverImageUrl" : "cover image url",
    "bookUrl" : "book url",
    "updated" : "2022-09-17",
    "created" : "2022-09-17"
}
```

## Get Books

### Get Books Request

```js
GET /api/bookstore
```

### Get Books Response

```js
200 Ok
```

```json
[
    {
    "id": "00000000-0000-0000-0000-000000000000",
    "title" : "title1",
    "author" : "Sarwan",
    "description" : "title1 description",
    "publishDate" : "2022-09-17",
    "coverImageUrl" : "cover image url",
    "bookUrl" : "book url",
    "updated" : "2022-09-17",
    "created" : "2022-09-17"
    }
]
```


## Get Book

### Get Book Request

```js
GET /api/bookstore/{{id}}
```

### Get Book Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "title" : "title1",
    "author" : "Sarwan",
    "description" : "title1 description",
    "publishDate" : "2022-09-17",
    "coverImageUrl" : "cover image url",
    "bookUrl" : "book url",
    "updated" : "2022-09-17",
    "created" : "2022-09-17"
}
```

## Update Book

### Update Book Request

```js
PUT /api/bookstore/{{id}}
```

```json
{
    "title" : "title1",
    "author" : "Sarwan",
    "description" : "title1 description",
    "publishDate" : "2022-09-17",
    "coverImageUrl" : "cover image url",
    "bookUrl" : "book url",
    "updated" : "2022-09-17",
    "created" : "2022-09-17"
}
```

### Update Book Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/api/bookstore/{{id}}
```

## Delete Book

### Delete Book Request

```js
DELETE /api/bookstore/{{id}}
```

### Delete Book Response

```js
204 No Content
```