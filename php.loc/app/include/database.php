<?php

$link = mysqli_connect('37.140.192.92', 'u1016723_vladimi', 'Dibikuper321', 'u1016723_technology_project');
mysqli_set_charset($link, "utf8");
if(mysqli_connect_errno())
{
    echo 'Ошибка в подключении к базе данных ('.mysqli_connect_errno().'):'. mysqli_connect_error();
    exit();
}
