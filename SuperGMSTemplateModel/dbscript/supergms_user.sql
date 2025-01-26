/*
SQLyog Community v13.1.6 (64 bit)
MySQL - 10.3.32-MariaDB-1:10.3.32+maria~focal-log : Database - supergms_user
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`supergms_user` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `supergms_user`;

/*Table structure for table `login_log` */

DROP TABLE IF EXISTS `login_log`;

CREATE TABLE `login_log` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `UserId` int(10) NOT NULL COMMENT '登录用户Id',
  `Login_Time` datetime NOT NULL COMMENT '登录时间',
  `Login_Ip` varchar(50) NOT NULL COMMENT '登录IP',
  `Client_Type` varchar(10) NOT NULL COMMENT '登录客户端类型',
  `Client_Version` varchar(10) NOT NULL COMMENT '登录客户端版本号',
  `Login_Device` varchar(300) NOT NULL COMMENT '登录设备信息',
  `CreatedDate` datetime NOT NULL COMMENT '创建时间',
  `CreatedBy` varchar(20) NOT NULL COMMENT '创建人',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `login_log` */

insert  into `login_log`(`id`,`UserId`,`Login_Time`,`Login_Ip`,`Client_Type`,`Client_Version`,`Login_Device`,`CreatedDate`,`CreatedBy`) values 
(1,1,'2025-01-26 12:18:12','PostmanRuntime/7.43.0','web','2.0.1','::ffff:192.168.0.10','2025-01-26 12:18:12','000000@qq.com'),
(2,1,'2025-01-26 12:18:18','PostmanRuntime/7.43.0','web','2.0.1','::ffff:192.168.0.10','2025-01-26 12:18:18','000000@qq.com'),
(3,1,'2025-01-26 12:18:20','PostmanRuntime/7.43.0','web','2.0.1','::ffff:192.168.0.10','2025-01-26 12:18:20','000000@qq.com'),
(4,1,'2025-01-26 12:18:20','PostmanRuntime/7.43.0','web','2.0.1','::ffff:192.168.0.10','2025-01-26 12:18:20','000000@qq.com');

/*Table structure for table `userinfo` */

DROP TABLE IF EXISTS `userinfo`;

CREATE TABLE `userinfo` (
  `UserId` int(10) NOT NULL COMMENT '系统中用户唯一标识',
  `RealName` varchar(40) DEFAULT NULL COMMENT '真实姓名',
  `Sex` int(11) DEFAULT NULL COMMENT '性别 1男 2女',
  `Birthday` datetime DEFAULT NULL COMMENT '出生日期',
  `Remark` varchar(100) DEFAULT NULL COMMENT '备注',
  `Status` int(10) DEFAULT NULL COMMENT '状态 1启用  2禁用',
  `CreatedDate` datetime NOT NULL COMMENT '创建时间',
  `UpdatedDate` datetime NOT NULL COMMENT '更新时间',
  `CreatedBy` varchar(50) DEFAULT NULL COMMENT '创建人',
  `UpdatedBy` varchar(50) DEFAULT NULL COMMENT '更新人',
  PRIMARY KEY (`UserId`) USING BTREE,
  KEY `Idx_CreatedDate` (`CreatedDate`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `userinfo` */

insert  into `userinfo`(`UserId`,`RealName`,`Sex`,`Birthday`,`Remark`,`Status`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) values 
(1,'supergms',1,'2000-01-01 17:40:32','备注',1,'2025-01-26 09:35:05','2025-01-26 09:35:10','systemm','systemm');

/*Table structure for table `userlogin` */

DROP TABLE IF EXISTS `userlogin`;

CREATE TABLE `userlogin` (
  `UserId` int(10) NOT NULL COMMENT '关联UserInfo的UserId',
  `LoginPassWord` varchar(50) NOT NULL COMMENT '登陆密码',
  `Email` varchar(50) DEFAULT NULL COMMENT 'Email',
  `CreatedDate` datetime NOT NULL COMMENT '创建时间',
  `UpdatedDate` datetime NOT NULL COMMENT '更新时间',
  `CreatedBy` varchar(50) DEFAULT NULL COMMENT '创建人',
  `UpdatedBy` varchar(50) DEFAULT NULL COMMENT '更新人',
  PRIMARY KEY (`UserId`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

/*Data for the table `userlogin` */

insert  into `userlogin`(`UserId`,`LoginPassWord`,`Email`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) values 
(1,'123456','000000@qq.com','2025-01-25 17:39:46','2025-01-25 17:39:49','system','system');

/*Table structure for table `user_login_log` */

DROP TABLE IF EXISTS `user_login_log`;

/*!50001 DROP VIEW IF EXISTS `user_login_log` */;
/*!50001 DROP TABLE IF EXISTS `user_login_log` */;

/*!50001 CREATE TABLE  `user_login_log`(
 `id` int(10) ,
 `UserId` int(10) ,
 `Login_Time` datetime ,
 `Login_Ip` varchar(50) ,
 `Client_Type` varchar(10) ,
 `Client_Version` varchar(10) ,
 `Login_Device` varchar(300) ,
 `CreatedDate` datetime ,
 `CreatedBy` varchar(20) ,
 `RealName` varchar(40) ,
 `Sex` int(11) ,
 `Birthday` datetime ,
 `Email` varchar(50) 
)*/;

/*View structure for view user_login_log */

/*!50001 DROP TABLE IF EXISTS `user_login_log` */;
/*!50001 DROP VIEW IF EXISTS `user_login_log` */;

/*!50001 CREATE VIEW `user_login_log` AS select `llog`.`id` AS `id`,`llog`.`UserId` AS `UserId`,`llog`.`Login_Time` AS `Login_Time`,`llog`.`Login_Ip` AS `Login_Ip`,`llog`.`Client_Type` AS `Client_Type`,`llog`.`Client_Version` AS `Client_Version`,`llog`.`Login_Device` AS `Login_Device`,`llog`.`CreatedDate` AS `CreatedDate`,`llog`.`CreatedBy` AS `CreatedBy`,`uinfo`.`RealName` AS `RealName`,`uinfo`.`Sex` AS `Sex`,`uinfo`.`Birthday` AS `Birthday`,`ulogin`.`Email` AS `Email` from ((`login_log` `llog` left join `userinfo` `uinfo` on(`llog`.`UserId` = `uinfo`.`UserId`)) left join `userlogin` `ulogin` on(`uinfo`.`UserId` = `ulogin`.`UserId`)) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
