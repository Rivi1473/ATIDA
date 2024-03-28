import { BarChart } from '@mui/x-charts/BarChart';
import React, { useEffect, useState } from 'react';
import {useNavigate} from 'react-router-dom'
import IconButton from '@mui/material/IconButton';
import HouseIcon from '@mui/icons-material/House';
import { PieChart ,pieArcLabelClasses } from '@mui/x-charts/PieChart';
import { useLocation } from 'react-router-dom';
import './css.css'
const CoronaSummery = () => {
  const navigate = useNavigate();
  const { state } = useLocation();
  let personalDetailsList = state.personalDetailsList;


  const now = new Date();
  const prevMonth = new Date(now.getFullYear(), now.getMonth() - 1);
  const prevMonthName = prevMonth.toLocaleString('en-US', { month: 'long' });
  const numDays = new Date(prevMonth.getFullYear(), prevMonth.getMonth() + 1, 0).getDate();

  let arrHelp=[];
  for (let i = 1; i <= numDays; i++) {
    debugger  
    const date = new Date(prevMonth.getFullYear(), prevMonth.getMonth(), i);
    let count = 0;
    personalDetailsList.forEach(personalDetails => {
      Date.parse(personalDetails.coronaDetails.positiveResultDate) <= Date.parse(date) &&Date.parse( personalDetails.coronaDetails.recoveryDate) > Date.parse(date)&&count++});
    arrHelp.push(count)
  }
  const [arr, setArr] = useState([0,...arrHelp]);

  let countNotVaccinated = 0;
  let countVaccinated = 0;
  personalDetailsList.forEach(personalDetails => {
    personalDetails.coronaDetails.firstVaccinationDate =="1900-01-01T00:00:00" ?countNotVaccinated++:countVaccinated++;

  });
  const [notVaccinated, setNotVaccinated] = useState(countNotVaccinated);
  const [vaccinated, setVaccinated] = useState(countVaccinated);
  const data = [
    { value: countVaccinated, label: 'are vaccinated' },
    { value: countNotVaccinated, label: 'not vaccinated' },

  ];
  
  const size = {
    width: 400,
    height: 200,
  };

  return (
    <>
         <IconButton sx={{backgroundColor:"#acdaff",color: "#004AAD",width:'45px',height:'45px'}}onClick={()=>{navigate('/')}}><HouseIcon/></IconButton> 
      <h2 align="center">Corona summery</h2>
      <h3 align="center">Graph of corona patients for {prevMonthName}</h3>
      {arr&&<BarChart
        series={[
          { data: arr },
        ]}
        height={290}
        xAxis={[{ data: [...Array(numDays).keys()].map(i => i + 1), scaleType: 'band' }]}
        margin={{ top: 10, bottom: 30, left: 40, right: 10 }}
        colors={['#004AAD']}
      />}
      <h3 align="center">A sample of how many are not vaccinated against Corona</h3>
      <p align="center">
    <PieChart 
    colors={['#acdaff', '#004AAD']}
      series={[
        {
          data,
        },
      ]}
      {...size}
    />
    </p>
    </>
  );
}
export default CoronaSummery;
