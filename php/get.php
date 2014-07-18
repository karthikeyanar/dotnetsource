<?php
function jsonResponse($param, $print = false, $header = true) {
    if (is_array($param)) {
        $out = $param;
    }
    $out = json_encode($out);
    if ($print) {
        if ($header) header('Content-type: application/json');
        echo $out;
        return;
    }
    return $out;
}
$type = $_GET['type']; 
//echo $type;
switch($type) {
	case 'groups':
		$response = array(
				array('value' => '0', 'text' => 'Guest'),
				array('value' => '1', 'text' => 'Service'),
				array('value' => '2', 'text' => 'Customer'),
				array('value' => '3', 'text' => 'Operator'),
				array('value' => '4', 'text' => 'Support'),
				array('value' => '5', 'text' => 'Admin'),
		);
	break;
}
die(jsonResponse($response));
?>