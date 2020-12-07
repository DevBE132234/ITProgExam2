-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 07, 2020 at 05:48 AM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `itprogtest`
--

-- --------------------------------------------------------

--
-- Table structure for table `personaldetails`
--

CREATE TABLE `personaldetails` (
  `ID` int(10) NOT NULL,
  `FirstName` varchar(20) NOT NULL,
  `MiddleName` varchar(20) NOT NULL,
  `LastName` varchar(20) NOT NULL,
  `Birthdate` varchar(50) NOT NULL,
  `Address` varchar(200) NOT NULL,
  `EducationalAttainment` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `personaldetails`
--

INSERT INTO `personaldetails` (`ID`, `FirstName`, `MiddleName`, `LastName`, `Birthdate`, `Address`, `EducationalAttainment`) VALUES
(2261, 'aasda', 'sdasd', 'asdasd', 'May/05/1956', 'asdas', 'Vocational'),
(2965, 'roda', 'jumaquio', 'ocampo', 'June/26/1974', 'jjjjjasdaasda', 'Highschool'),
(5196, 'jjjjjj', 'jjjjjjj', 'jjjjjj', 'April/26/1974', 'jjjjj', 'Highschool'),
(6995, 'jjjjjj', 'jjjjjjj', 'jjjjjj', 'April/23/1976', 'jjjjj', 'Bachelors Degree'),
(9029, 'jjjjjj', 'jjjjjjj', 'jjjjjj', 'July/02/1997', 'jjjjj', 'Bachelors Degree');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `personaldetails`
--
ALTER TABLE `personaldetails`
  ADD PRIMARY KEY (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
