-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 07, 2021 at 04:45 PM
-- Server version: 10.1.40-MariaDB
-- PHP Version: 7.3.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `my_new_test_data_base`
--

-- --------------------------------------------------------

--
-- Table structure for table `mytest_hobbies`
--

CREATE TABLE `mytest_hobbies` (
  `Id` int(11) NOT NULL,
  `Hobby` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mytest_hobbies`
--

INSERT INTO `mytest_hobbies` (`Id`, `Hobby`) VALUES
(0, 'Reading News'),
(1, 'Reading Fiction'),
(2, 'Writing Fiction'),
(3, 'Writing'),
(4, 'Cooking');

-- --------------------------------------------------------

--
-- Table structure for table `mytest_jobs`
--

CREATE TABLE `mytest_jobs` (
  `Id` int(11) NOT NULL,
  `Job` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mytest_jobs`
--

INSERT INTO `mytest_jobs` (`Id`, `Job`) VALUES
(0, NULL),
(1, 'Teacher'),
(2, 'Engineer'),
(3, 'Doctor'),
(4, 'Student');

-- --------------------------------------------------------

--
-- Table structure for table `mytest_people`
--

CREATE TABLE `mytest_people` (
  `Id` int(11) NOT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `Age` int(3) DEFAULT NULL,
  `Hobbies_ID` int(11) DEFAULT NULL,
  `Jobs_ID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mytest_people`
--

INSERT INTO `mytest_people` (`Id`, `Name`, `Age`, `Hobbies_ID`, `Jobs_ID`) VALUES
(0, 'Pete', 100, 0, 1),
(1, 'Mark', 5, NULL, NULL),
(2, 'Bob', 33, 2, 2),
(3, 'Lulu', 22, 1, 4),
(4, 'Mary', 34, 1, 3),
(5, 'Alma', 12, 4, 4);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `mytest_hobbies`
--
ALTER TABLE `mytest_hobbies`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `mytest_jobs`
--
ALTER TABLE `mytest_jobs`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `mytest_people`
--
ALTER TABLE `mytest_people`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Hobbies` (`Hobbies_ID`),
  ADD KEY `Jobs` (`Jobs_ID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `mytest_people`
--
ALTER TABLE `mytest_people`
  ADD CONSTRAINT `Hobbies` FOREIGN KEY (`Hobbies_ID`) REFERENCES `mytest_hobbies` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
