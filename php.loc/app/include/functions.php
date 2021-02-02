<?php

function get_categories($link){
    
    global $link;
    
    $sql = "SELECT * FROM `Computerinfo`";
    
    $result = mysqli_query($link, $sql);
 
    $categories = mysqli_fetch_all($result, MYSQLI_ASSOC); 
    return  $categories;
}

$categories = get_categories($link);


function get_oborudovanie(){
    global $link;
    
    $sql = "SELECT * FROM `Computerinfo`";
            
    $result = mysqli_query($link, $sql);
    
    $posts = mysqli_fetch_assos($result, MYSQLI_ASSOC);
    
    return $posts;
    
    
}