create table login_log
(
    id       int auto_increment
        primary key,
    uid      int      not null,
    log_time datetime not null,
    status   int      not null
);

create table profile_table
(
    id     int auto_increment
        primary key,
    name   varchar(20)  not null,
    gender int          not null,
    email  varchar(500) null,
    phone  varchar(20)  null,
    job    varchar(50)  not null,
    title  varchar(50)  not null
);

create table transfer_history
(
    id        int auto_increment
        primary key,
    uid_link  int         not null,
    op_time   datetime    not null,
    pre_job   varchar(50) not null,
    pre_title varchar(50) not null,
    new_job   varchar(50) not null,
    new_title varchar(50) not null
);

create table user_table
(
    id         int auto_increment
        primary key,
    username   varchar(20)  not null,
    password   varchar(128) not null,
    isAdmin    int          not null,
    profile_id int          not null
);

