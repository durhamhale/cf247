# Customer API

## Endpoints

### GET /api/customers

Returns all customer records.

#### Request format

```
(empty)
```

#### Response format

```
[
    {
        "id": "",           // string
        "firstName": "",    // string
        "surname": "",      // string
        "email": "",        // string
        "password": ""      // string
    }
    ...
]
```

### GET /api/customers/{id}

Returns a single customer record for the provided ID.

#### Request format

```
(empty)
```

#### Response format

```
{
    "id": "",           // string
    "firstName": "",    // string
    "surname": "",      // string
    "email": "",        // string
    "password": ""      // string
}
```

### POST /api/customers

Creates a customer record from the request body.

#### Request format (application/json)

```
{
    "firstName": "",    // string
    "surname": "",      // string
    "email": "",        // string
    "password": ""      // string
}
```

#### Response format

```
{
    "id": "",           // string
    "firstName": "",    // string
    "surname": "",      // string
    "email": "",        // string
    "password": ""      // string
}
```

### PUT /api/customers/{id}

Updates a customer record from the request body.

#### Request format (application/json)

```
{
    "firstName": "",    // string
    "surname": "",      // string
    "email": "",        // string
    "password": ""      // string
}
```

#### Response format

```
(empty)
```

### DELETE /api/customers/{id}

Returns the customer record with the provided ID.

#### Request format

```
(empty)
```

#### Response format

```
(empty)
```
