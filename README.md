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

## Docker

To run in the dockerized dev environment run `docker-compose up`

## Sample web requests

A [Postman](https://www.getpostman.com/) collection of all the available endpoints can be found in the root of the project in the file `CF247.postman_collection.json`
