<?php
require_once 'include/database.php';
require_once 'include/functions.php';

?>
<?php
?>

<DOCTYPE html>
<html lang="ru">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Учет абонентов АТС</title>

    <!-- Bootstrap -->
    <link href="public/css/bootstrap.css" rel="stylesheet">
    <link href="public/css/font-awesome.css" rel="stylesheet">
    <link href="public/css/style.css" rel="stylesheet">

  </head>
  <body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#responsive-menu">
                    <span class="sr-only">Открыть навигацию</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="/">Учет абонентов АТС</a>
            </div>
            <div class="collapse navbar-collapse" id="responsive-menu">
                <ul class="nav navbar-nav">
                    <?php
                        $categories = array (
                            array(
                            'category_id' => 1,
                            'category_title' =>'Бухгалтерия',
                            ),
                            array(
                            'category_id' => 2,
                            'category_title' =>'Инженерный отдел',
                            ),
                            array(
                            'category_id' => 3,
                            'category_title' =>'Переговорная',
                            )
                        );
                    ?>
              
                        
                        <?php if(count($categories) === 0): ?>
                    <li><a href ="#"> <i class="glyphicon glyphicon-plus-sign"></i> Добавить категорию</a></li>
                        <?php else : ?>
                    
                    <?php    foreach($categories as $category): ?>
                         <li><a href ="/category.php?id=<?=$category["category_id"]?>"><?=$category["category_title"]?></a></li>;
                        <?php endforeach; ?>
                        <?php endif; ?>
                </ul>
            </div>
        </div>
    </div>
      </br>
      </br>
      </br>
      </br>
<?php

$result = mysqli_query($link, "SELECT * FROM `Computerinfo`");
while ($komp = mysqli_fetch_assoc($result))
{
 echo $komp['ID'];
  echo '<br>';
  
 echo $komp['Ozu'];
 echo $komp['Videokarta'];
 echo $komp['Processor'];
 echo $komp['Memory'];
 echo $komp['Os'];
 echo '<br>';
 
}
?>
      </br>
      </br>
      </br>
       <div class="container">
          <div class="alert alert-danger">
              <pre><?=$categories[1]['category_title']?></pre> 
          </div>
      </div>
      


