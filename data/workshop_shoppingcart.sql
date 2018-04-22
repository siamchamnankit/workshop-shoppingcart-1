# ************************************************************
# Sequel Pro SQL dump
# Version 4541
#
# http://www.sequelpro.com/
# https://github.com/sequelpro/sequelpro
#
# Host: 127.0.0.1 (MySQL 5.5.58)
# Database: workshop_shoppingcart
# Generation Time: 2018-04-22 11:49:21 +0000
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
  `shippingFee` decimal(3,2) DEFAULT NULL,
  `shippingId` int(10) DEFAULT NULL,
  `createDatetime` datetime DEFAULT NULL,
  `updateDatetime` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



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
  `stockAvailability` int(3) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;

INSERT INTO `products` (`id`, `name`, `gender`, `age`, `price`, `availability`, `brand`, `stockAvailability`)
VALUES
	(1,'Balance Training Bicycle','NEUTRAL','3_to_5',119.95,'InStock','SportsFun',NULL),
	(2,'43 Piece dinner Set','FEMALE','3_to_5',12.95,'InStock','CoolKidz',NULL),
	(3,'Horses and Unicorns Set','NEUTRAL','3_to_5',24.95,'InStock','CoolKidz',NULL);

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
