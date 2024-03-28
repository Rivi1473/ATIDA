import React, { useEffect,useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import ModeEditIcon from '@mui/icons-material/ModeEdit';
import IconButton from '@mui/material/IconButton';
import DeleteIcon from '@mui/icons-material/Delete'
import {useNavigate} from 'react-router-dom'
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import CoronavirusIcon from '@mui/icons-material/Coronavirus';
import Avatar from '@mui/material/Avatar';
import axios from 'axios';
import moment from 'moment';
import './css.css'


const PersonalDetailsList = () => {
    const [personalDetailsList, SetPersonalDetailsList] = useState(null);
    const [open, setOpen] = useState(false);
    const [name, setName] = useState(null);
    const [coronaDetails, setCoronaDetails] = useState(null);
    const navigate = useNavigate();

    const goToServer = async () => {
        
      try {
        const response= await axios.get("https://localhost:7294/api/PersonalDetails")
        SetPersonalDetailsList(response.data); 
      } catch (error) {
        console.error('Error fetching data:', error);
      }
      };
    useEffect(()=>{goToServer()},[]);

    const deletePersonalDetails=async(id,id2)=>{            
            let url2='https://localhost:7294/api/PersonalDetails/'+id
            const response2=  await fetch(url2, {method: 'DELETE',}) 
            let url='https://localhost:7294/api/CoronaDetails/'+id2
            const response =  await fetch(url, {method: 'DELETE',})  
            let copy=personalDetailsList.filter(x=>x.id!=id)
            SetPersonalDetailsList(copy);     
    }

    const updatePersonalDetails=(personalDetails)=>{
            navigate("/updateDetails", { state: { personalDetails } });     
        }

    const addPersonalDetails=()=>{
      let personalDetails={
        id:0,
        name: "",
        tz: "",
        city: "",
        streetName: "",
        numberHouse: 0,
        bornDate: "1900-01-01",
        phone: "",
        mobilePhone: "",
        imageFile:null,
        coronaDetails: {
          firstVaccinationDate:"1900-01-01",
          firstmanufacturerVaccination: "",
          secondVaccinationDate: "1900-01-01",
          secondmanufacturerVaccination: "",
          thirdVaccinationDate: "1900-01-01",
          thirdmanufacturerVaccination: "",
          fourthVaccinationDate: "1900-01-01",
          fourthmanufacturerVaccination: "",
          positiveResultDate: "1900-01-01",
          recoveryDate: "1900-01-01"
        }
      }
      navigate("/addDetails", { state: { personalDetails } });     
    }
    
    const showCoronaDitails = async (personalDetails) => {
        
        setName(personalDetails.name)
        setOpen(true);
        setCoronaDetails(personalDetails.coronaDetails);
    };

    const handleClose = () => {
      setOpen(false);
    };

    const coronaSummery=()=>{
      navigate("coronaSummery",{ state: { personalDetailsList } })
    }

    return (  <>
    <h1>Corona management system for HMO</h1>
    <TableContainer component={Paper}>
      <Table className='table'>
        <TableHead>
          <TableRow>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}} align="center"><b>Profil</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>ID</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>Name</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>City</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>Street</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>House number</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>Date of birth</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>Phone</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>Mobile phone</b></TableCell> 
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>Corona details</b></TableCell> 
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>Edit</b></TableCell>       
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>Delete</b></TableCell>       
          </TableRow>
        </TableHead>
         <TableBody>
    {personalDetailsList&&personalDetailsList.map(
        personalDetails=>{return <TableRow key={personalDetails.id}>
                      
             <TableCell align="center"><Avatar
               src={personalDetails.imageUrl}
              /></TableCell>
             <TableCell align="center">{personalDetails.tz}</TableCell>
        <TableCell align="center">{personalDetails.name}</TableCell>
        <TableCell align="center">{personalDetails.city}</TableCell>
        <TableCell align="center">{personalDetails.streetName}</TableCell>
        <TableCell align="center">{personalDetails.numberHouse}</TableCell>
        <TableCell align="center">{moment(personalDetails.bornDate).format('DD/MM/YYYY')}</TableCell>
        <TableCell align="center">{personalDetails.phone}</TableCell>
        <TableCell align="center">{personalDetails.mobilePhone}</TableCell>
        <TableCell align="center">{<IconButton  onClick={()=>{showCoronaDitails(personalDetails)}}><CoronavirusIcon/></IconButton>}</TableCell>        
        <TableCell align="center">{<IconButton  onClick={()=>{updatePersonalDetails(personalDetails)}}><ModeEditIcon/></IconButton>}</TableCell>
        <TableCell align="center">{<IconButton  onClick={()=>{deletePersonalDetails(personalDetails.id,personalDetails.coronaDetailsId)}}><DeleteIcon /></IconButton>}</TableCell>
    </TableRow>})}
        </TableBody> 
      </Table>
    </TableContainer>
    <Button variant="outlined"sx={{backgroundColor:"#acdaff",color: "#004AAD",margin: '30px 70px 0 0'}} onClick={addPersonalDetails}>Add new patient</Button>
    <Button variant="outlined"sx={{backgroundColor:"#acdaff",color: "#004AAD",margin: '30px 0 0 70px'}} onClick={coronaSummery}>Corona summery</Button>

      {coronaDetails&&<Dialog
        open={open}
        onClose={handleClose}>
            <DialogTitle sx={{backgroundColor:"#acdaff",color: "#004AAD"}} align="center"  id="alert-dialog-title">
          {name}
        </DialogTitle>
        <DialogContent>
          <DialogContentText align="center" id="alert-dialog-description">
          <TableContainer component={Paper}>
            <h3>Corona vaccination chart</h3>
       <Table className='table'>
        <TableHead>
          <TableRow>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>The vaccination number</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>Date of receiving the vaccine</b></TableCell>
            <TableCell sx={{backgroundColor:"#acdaff",color: "#004AAD"}}align="center"><b>The manufacturer of the vaccine</b></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          
            <TableRow>
              <TableCell align="center">1</TableCell>
              <TableCell align="center">{coronaDetails.firstVaccinationDate=="1900-01-01T00:00:00"?"-":moment(coronaDetails.firstVaccinationDate).format('DD/MM/YYYY')}</TableCell>
              <TableCell align="center">{coronaDetails.firstmanufacturerVaccination==""?"-":coronaDetails.firstmanufacturerVaccination}</TableCell>
              
            </TableRow>
            <TableRow>   
              <TableCell align="center">2</TableCell>
              <TableCell align="center">{coronaDetails.secondVaccinationDate=="1900-01-01T00:00:00"?"-":moment(coronaDetails.secondVaccinationDate).format('DD/MM/YYYY')}</TableCell>
              <TableCell align="center">{coronaDetails.secondmanufacturerVaccination==""?"-":coronaDetails.secondmanufacturerVaccination}</TableCell>
              
            </TableRow>
            <TableRow>   
              <TableCell align="center">3</TableCell>
              <TableCell align="center">{coronaDetails.thirdVaccinationDate=="1900-01-01T00:00:00"?"-":moment(coronaDetails.thirdVaccinationDate).format('DD/MM/YYYY')}</TableCell>
              <TableCell align="center">{coronaDetails.thirdmanufacturerVaccination==""?"-":coronaDetails.thirdmanufacturerVaccination}</TableCell>
              
            </TableRow>
            <TableRow>   
              <TableCell align="center">4</TableCell>
              <TableCell align="center">{coronaDetails.fourthVaccinationDate=="1900-01-01T00:00:00"?"-":moment(coronaDetails.fourthVaccinationDate).format('DD/MM/YYYY')}</TableCell>
              <TableCell align="center">{coronaDetails.fourthmanufacturerVaccination==""?"-":coronaDetails.fourthmanufacturerVaccination}</TableCell>         
            </TableRow>
        </TableBody>
      </Table>
    </TableContainer>
    <p>{coronaDetails.positiveResultDate=="1900-01-01T00:00:00"?"There is no positive answer to Corona":("Was found to be positive for Corona on "+moment(coronaDetails.positiveResultDate).format('DD/MM/YYYY')+(coronaDetails.recoveryDate=="1900-01-01T00:00:00"?"and there is still no negative answer":(" and received a negative answer on "+moment(coronaDetails.recoveryDate).format('DD/MM/YYYY'))))}</p>
    </DialogContentText>
    </DialogContent>
    <Button  onClick={handleClose} sx={{backgroundColor:"#acdaff",color: "#004AAD",width:"150px",margin: 'auto auto 15px auto'}} autoFocus>CLOSE</Button>
    </Dialog>}  

    </>);

}
 
export default PersonalDetailsList;