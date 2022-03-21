CREATE TABLE public.applicationevents (
id uuid NOT NULL,
applicationid uuid NOT NULL,
"type" int4 NOT NULL,
createddatetime timestamp NOT NULL
);

CREATE TABLE public.applications (
id uuid NOT NULL,
"name" varchar NOT NULL,
userid uuid NOT NULL,
createddatetime timestamp NOT NULL,
isremoved bool NOT NULL DEFAULT false
);

CREATE TABLE public.users (
id uuid NOT NULL,
email varchar NOT NULL,
passwordhash varchar NOT NULL,
createddatetime timestamp NOT NULL,
CONSTRAINT users_pk PRIMARY KEY (id)
);
