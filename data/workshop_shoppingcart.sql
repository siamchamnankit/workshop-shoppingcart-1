# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 5.5.60)
# Database: workshop_shoppingcart
# Generation Time: 2018-04-24 08:45:51 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table cart
# ------------------------------------------------------------

DROP TABLE IF EXISTS `cart`;

CREATE TABLE `cart` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `userId` int(10) DEFAULT NULL,
  `subtotal` decimal(6,2) DEFAULT NULL,
  `total` decimal(6,2) DEFAULT NULL,
  `shippingMethod` varchar(20) DEFAULT NULL,
  `shippingFee` decimal(5,2) DEFAULT NULL,
  `shippingId` int(10) DEFAULT NULL,
  `createDatetime` datetime DEFAULT NULL,
  `updateDatetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `cart` WRITE;
/*!40000 ALTER TABLE `cart` DISABLE KEYS */;

INSERT INTO `cart` (`id`, `userId`, `subtotal`, `total`, `shippingMethod`, `shippingFee`, `shippingId`, `createDatetime`, `updateDatetime`)
VALUES
	(1,1,12.95,62.95,'Cash on Delivery',50.00,1,'0000-00-00 00:00:00','0000-00-00 00:00:00');

/*!40000 ALTER TABLE `cart` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table cart_product
# ------------------------------------------------------------

DROP TABLE IF EXISTS `cart_product`;

CREATE TABLE `cart_product` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `cartId` int(10) DEFAULT NULL,
  `productId` int(10) DEFAULT NULL,
  `quantity` int(3) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `cart_product` WRITE;
/*!40000 ALTER TABLE `cart_product` DISABLE KEYS */;

INSERT INTO `cart_product` (`id`, `cartId`, `productId`, `quantity`)
VALUES
	(1,1,2,1);

/*!40000 ALTER TABLE `cart_product` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table order
# ------------------------------------------------------------

DROP TABLE IF EXISTS `order`;

CREATE TABLE `order` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `cartId` int(10) DEFAULT NULL,
  `userId` int(10) DEFAULT NULL,
  `subtotal` decimal(6,2) DEFAULT NULL,
  `total` decimal(6,2) DEFAULT NULL,
  `shippingMethod` varchar(20) DEFAULT NULL,
  `shippingFee` decimal(3,2) DEFAULT NULL,
  `shippingId` int(10) DEFAULT NULL,
  `createDatetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



# Dump of table order_products
# ------------------------------------------------------------

DROP TABLE IF EXISTS `order_products`;

CREATE TABLE `order_products` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `orderId` int(10) DEFAULT NULL,
  `productId` int(10) DEFAULT NULL,
  `quantity` int(3) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `gender` enum('FEMALE','NEUTRAL','MALE') DEFAULT NULL,
  `age` enum('3_to_5','6_to_8','Baby','over8','Toddler') DEFAULT NULL,
  `price` decimal(6,2) DEFAULT NULL,
  `availability` enum('InStock','SoldOut') DEFAULT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `stockAvailability` int(3) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



# Dump of table products
# ------------------------------------------------------------

DROP TABLE IF EXISTS `products`;

CREATE TABLE `products` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `gender` enum('FEMALE','NEUTRAL','MALE') DEFAULT NULL,
  `age` enum('3_to_5','6_to_8','Baby','over8','Toddler') DEFAULT NULL,
  `price` decimal(6,2) DEFAULT NULL,
  `availability` enum('InStock','SoldOut') DEFAULT NULL,
  `brand` varchar(50) DEFAULT NULL,
  `stockAvailability` int(3) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;

INSERT INTO `products` (`id`, `name`, `gender`, `age`, `price`, `availability`, `brand`, `stockAvailability`)
VALUES
	(1,'Balance Training Bicycle','NEUTRAL','3_to_5',119.95,'InStock','SportsFun',0),
	(2,'43 Piece dinner Set','FEMALE','3_to_5',12.95,'InStock','CoolKidz',0),
	(3,'Horses and Unicorns Set','NEUTRAL','3_to_5',24.95,'InStock','CoolKidz',0),
	(4,'Hoppity Ball 26 inch','NEUTRAL','3_to_5',29.95,'InStock','SportsFun',0),
	(5,'Sleeping Queens Board Game','FEMALE','3_to_5',12.95,'SoldOut','CoolKidz',0),
	(6,'Princess Palace','FEMALE','3_to_5',24.95,'InStock','CoolKidz',0),
	(7,'Best Friends Forever Magnetic Dress Up','FEMALE','3_to_5',24.95,'InStock','CoolKidz',0),
	(8,'City Gragage Truck Lego','NEUTRAL','3_to_5',19.95,'SoldOut','Lego',0),
	(9,'Kettrike Tricycle','NEUTRAL','3_to_5',249.95,'SoldOut','SportsFun',0),
	(10,'Princess Training Bicycle','FEMALE','3_to_5',119.95,'SoldOut','SportsFun',0),
	(11,'Earth DVD Game','NEUTRAL','over8',34.99,'InStock','VideoVroom',0),
	(12,'Twilight Board Game','NEUTRAL','over8',24.95,'InStock','GeekToys',0),
	(13,'Settlers of Catan Board Game','NEUTRAL','over8',44.95,'InStock','GeekToys',0),
	(14,'OMG - Gossip Girl Board Game ','FEMALE','over8',24.95,'InStock','GeekToys',0),
	(15,'Sailboat','MALE','over8',24.95,'InStock','CoolKidz',0),
	(16,'Scrabble ','NEUTRAL','over8',19.95,'InStock','GeekToys',0),
	(17,'Star War Darth Vader Lego','MALE','6_to_8',39.95,'InStock','GeekToys',0),
	(18,'Snoopy Sno-Cone Machine','NEUTRAL','6_to_8',24.95,'InStock','Modelz',0),
	(19,'Gourmet Cupcake Maker','FEMALE','6_to_8',39.95,'InStock','CoolKidz',0),
	(20,'Creator Beach House Lego','NEUTRAL','6_to_8',39.95,'SoldOut','Lego',0),
	(21,'Jacques the Peacock Play and Grow','NEUTRAL','Toddler',12.95,'InStock','CoolKidz',0),
	(22,'Nutbrown Hare','NEUTRAL','Baby',12.99,'SoldOut','CoolKidz',0),
	(23,'Dancing Alligator','NEUTRAL','Baby',19.95,'InStock','CoolKidz',0),
	(24,'Mashaka the Monkey','NEUTRAL','Baby',36.95,'InStock','BarnyardBlast',0),
	(25,'Sleep Sheep','NEUTRAL','Baby',39.00,'InStock','BarnyardBlast',0),
	(26,'Les Dollie Toffee Apple','FEMALE','Toddler',24.95,'InStock','CoolKidz',0),
	(27,'Sand Play Set','NEUTRAL','Toddler',24.95,'InStock','Modelz',0),
	(28,'Melody Express Musical Train','MALE','Toddler',42.95,'InStock','Modelz',0),
	(29,'My First LEGO DUPLO Set','NEUTRAL','Toddler',19.95,'SoldOut','Lego',0),
	(30,'Fisher-Price stroller','FEMALE','Toddler',25.99,'InStock','CoolKidz',0),
	(31,'Mortimer the Moose Play and Grow','NEUTRAL','Toddler',12.95,'InStock','CoolKidz',0);

/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table shipping_address
# ------------------------------------------------------------

DROP TABLE IF EXISTS `shipping_address`;

CREATE TABLE `shipping_address` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `userId` int(10) DEFAULT NULL,
  `fullname` varchar(100) DEFAULT NULL,
  `address1` varchar(100) DEFAULT NULL,
  `address2` varchar(100) DEFAULT NULL,
  `city` varchar(100) DEFAULT NULL,
  `province` varchar(100) DEFAULT NULL,
  `postcode` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



# Dump of table shop_profile
# ------------------------------------------------------------

DROP TABLE IF EXISTS `shop_profile`;

CREATE TABLE `shop_profile` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `shop_profile` WRITE;
/*!40000 ALTER TABLE `shop_profile` DISABLE KEYS */;

INSERT INTO `shop_profile` (`id`, `name`, `address`)
VALUES
	(1,'SCK SHOP','SCK Dojo');

/*!40000 ALTER TABLE `shop_profile` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table user
# ------------------------------------------------------------

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fullname` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;




/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
