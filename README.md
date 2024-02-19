# Generic Repository using Dapper
## Introduction
This is the source code for the blog post explaining how to use the Generic Repository pattern in Dapper.
## Project
- Technology: ASP.NET 8, Postgres 16, and Dapper.
## How To Run
### Database
Open up PG Admin's SQL Query editor and create the database and its tables. In this project, the database is called `GenericRepoDapperDb`. The queries to do that can be found below:
#### Database
```sql
-- Database: GenericRepoDapperDb

-- DROP DATABASE IF EXISTS "GenericRepoDapperDb";

CREATE DATABASE "GenericRepoDapperDb"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
```
#### Tables
```sql
-- Table: public.categories

-- DROP TABLE IF EXISTS public.categories;

CREATE TABLE IF NOT EXISTS public.categories
(
    id integer NOT NULL DEFAULT nextval('categories_id_seq'::regclass),
    name character varying(255) COLLATE pg_catalog."default" NOT NULL,
    created_at timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT categories_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.categories
    OWNER to postgres;

-- Table: public.products

-- DROP TABLE IF EXISTS public.products;

CREATE TABLE IF NOT EXISTS public.products
(
    id integer NOT NULL DEFAULT nextval('products_id_seq'::regclass),
    name character varying(255) COLLATE pg_catalog."default" NOT NULL,
    description text COLLATE pg_catalog."default",
    category_id integer NOT NULL,
    created_at timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT products_pkey PRIMARY KEY (id),
    CONSTRAINT products_category_id_fkey FOREIGN KEY (category_id)
        REFERENCES public.categories (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.products
    OWNER to postgres;
```

### Application
1. Clone or download the repository.
2. Open the project containing folder in Visual Studio or JetBrains Rider.
3. Build the project.
4. Run.

## Article
The article can be found here:
[https://dev.to/amjadmh73/dapper-generic-repository-5fil](https://dev.to/amjadmh73/dapper-generic-repository-5fil)