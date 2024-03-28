import React, { useState, useEffect } from 'react';
import { useNavigate, useLocation } from 'react-router-dom';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Table from '@mui/material/Table';
import IconButton from '@mui/material/IconButton';
import HouseIcon from '@mui/icons-material/House';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import { useForm } from 'react-hook-form'
import axios from 'axios';
import Avatar from '@mui/material/Avatar';
import './css.css'

const AddUpdateDetails = () => {
  const { register, handleSubmit, formState: { errors, isValid } } = useForm({ mode: 'onBlur', validateCriteriaMode: 'firstError' });
  const [selectedFile, setSelectedFile] = useState(null);
  const [errorText, setErrorText] = useState(" ");

  const [currentDate] = useState(new Date().toISOString().slice(0, 10));
  const navigate = useNavigate();
  const { state } = useLocation();
  let personalDetails = state.personalDetails;
  const [imageSrc, setImageSrc] = useState(personalDetails.id == 0 ? null : personalDetails.imageUrl);


  const fillCoronaDetails = () => {
    let coronaDetails = {
      "firstVaccinationDate": personalDetails.coronaDetails.firstVaccinationDate,
      "firstmanufacturerVaccination": personalDetails.coronaDetails.firstmanufacturerVaccination,
      "secondVaccinationDate": personalDetails.coronaDetails.secondVaccinationDate,
      "secondmanufacturerVaccination": personalDetails.coronaDetails.secondmanufacturerVaccination,
      "thirdVaccinationDate": personalDetails.coronaDetails.thirdVaccinationDate,
      "thirdmanufacturerVaccination": personalDetails.coronaDetails.thirdmanufacturerVaccination,
      "fourthVaccinationDate": personalDetails.coronaDetails.fourthVaccinationDate,
      "fourthmanufacturerVaccination": personalDetails.coronaDetails.fourthmanufacturerVaccination,
      "positiveResultDate": personalDetails.coronaDetails.positiveResultDate,
      "recoveryDate": personalDetails.coronaDetails.recoveryDate
    }
    return coronaDetails
  }

  const fillPersonalDetails = () => {
    let formData = new FormData();
    formData.append("ImageFile", selectedFile);
    formData.append("Name", personalDetails.name)
    formData.append("Tz", personalDetails.tz)
    formData.append("City", personalDetails.city)
    formData.append("StreetName", personalDetails.streetName)
    formData.append("NumberHouse", personalDetails.numberHouse)
    formData.append("BornDate", personalDetails.bornDate)
    formData.append("Phone", personalDetails.phone)
    formData.append("MobilePhone", personalDetails.mobilePhone)
    return formData
  }

  const updateDetails = async () => {
    let formData = fillPersonalDetails()
    let coronaDetails = fillCoronaDetails()
    let response = null
    formData.append("CoronaDetailsId", personalDetails.coronaDetails.id)

    response = await axios.put('https://localhost:7294/api/PersonalDetails/' + personalDetails.id, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    }).then((response) => {
      setErrorText(" ")
    })
      .catch((error) => {
        if (error.response) {
          setErrorText(error.response.data)
        }
      })
    response = await axios.put('https://localhost:7294/api/CoronaDetails/' + personalDetails.coronaDetailsId, coronaDetails).then((response) => {
      setErrorText(" ")
    })
      .catch((error) => {
        if (error.response) {
          setErrorText(error.response.data)

        }
      })

  }

  const addDetails = async () => {
    let formData = fillPersonalDetails();
    let coronaDetails = fillCoronaDetails();
    let x = 0
    let response = await axios.post('https://localhost:7294/api/CoronaDetails', coronaDetails).then((response) => {
      formData.append("CoronaDetailsId", response.data.id)
      setErrorText(" ")
      x = 1
    }).catch((error) => {
      if (error.response) {
        setErrorText(error.response.data)
      }
    });;
    if (x == 0) {
      let response2 = await axios.post('https://localhost:7294/api/PersonalDetails', formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      }).then((response) => { setErrorText(" ") }).catch((error) => {
        if (error.response) {
          if(error.response.status==400)
            setErrorText(error.response.data)
        }
      });;
    }

  }

  const onSubmit = () => {
    personalDetails.id == 0 ? addDetails() : updateDetails()
  }

  const handleFileChange = (event) => {
    setSelectedFile(event.target.files[0]);
    if (event.target.files[0]) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setImageSrc(reader.result);
      };
      reader.readAsDataURL(event.target.files[0]);
    }
  };
  return (<>
    <IconButton sx={{ backgroundColor: "#acdaff", color: "#004AAD", width: '45px', height: '45px' }} onClick={() => { navigate('/') }}><HouseIcon /></IconButton>
    <form align="center" onSubmit={handleSubmit(onSubmit)}>
      <h2>Personal details</h2>
      <p align="center"><Avatar sx={{ width: 75, height: 75 }} src={imageSrc} /></p>
      <div className={personalDetails.id == 0 ? "grid" : "grid2"}>
        <TextField required error={!!errors.name} InputLabelProps={{ style: { color: errors.name ? '#e6001a' : '#004AAD' } }} helperText={errors.name ? (
          errors.name.type === 'required' ? 'required field' :
            errors.name.type === 'minLength' ? 'At least 2 characters' :
              errors.name.type === 'pattern' ? 'only letters' : '') : ' '} label="Name" {...register("name", { required: true, minLength: 2, pattern: /^([A-Za-z]{2})(\s*[A-Za-z\s]*)?$/i })} defaultValue={personalDetails.name} variant="standard" onChange={(e) => personalDetails.name = e.target.value} />
        <TextField required error={!!errors.tz} InputLabelProps={{ style: { color: errors.tz ? '#e6001a' : '#004AAD' } }} helperText={errors.tz ? (
          errors.tz.type === 'required' ? 'required field' :
            errors.tz.type === 'pattern' ? '9 numbers are required' : '') : ' '} label="Id" {...register("tz", { required: true, pattern: /^[0-9]{9}$/ })} defaultValue={personalDetails.tz} variant="standard" onChange={(e) => { personalDetails.tz = e.target.value }} />
        <TextField required error={!!errors.city} InputLabelProps={{ style: { color: errors.city ? '#e6001a' : '#004AAD' } }} helperText={errors.city ? (
          errors.city.type === 'required' ? 'required field' :
            errors.city.type === 'minLength' ? 'At least 2 characters' :
              errors.city.type === 'pattern' ? 'only letters' : '') : ' '} label="City"{...register("city", { required: true, minLength: 2, pattern: /^([A-Za-z]{2})(\s*[A-Za-z\s]*)?$/i })} defaultValue={personalDetails.city} variant="standard" onChange={(e) => personalDetails.city = e.target.value} />
        <TextField required error={!!errors.street} InputLabelProps={{ style: { color: errors.street ? '#e6001a' : '#004AAD' } }} helperText={errors.street ? (
          errors.street.type === 'required' ? 'required field' :
            errors.street.type === 'minLength' ? 'At least 2 characters' : '') : ' '} label="Street" {...register("street", { required: true, minLength: 2, })} defaultValue={personalDetails.streetName} variant="standard" onChange={(e) => personalDetails.streetName = e.target.value} />
        <TextField required error={!!errors.houseNumber} InputLabelProps={{ style: { color: errors.houseNumber ? '#e6001a' : '#004AAD' }, shrink: true }} helperText={errors.houseNumber ? (
          errors.houseNumber.type === 'required' ? 'required field' :
            errors.houseNumber.type === 'min' ? 'positive number required' : '') : ' '} label="House number" {...register("houseNumber", { required: true, min: 0 })} type="number" defaultValue={personalDetails.numberHouse} variant="standard" onChange={(e) => personalDetails.numberHouse = e.target.value} />
        <TextField required error={!!errors.bornDate} InputLabelProps={{ style: { color: errors.bornDate ? '#e6001a' : '#004AAD' } }} helperText={errors.bornDate ? (
          errors.bornDate.type === 'required' ? 'required field' :
            errors.bornDate.type === 'max' ? 'Invalid date' : '') : ' '} label="Date of birth"{...register("bornDate", { required: true, max: currentDate })} type="date" defaultValue={personalDetails.id != 0 ? personalDetails.bornDate.slice(0, 10) : ""} variant="standard" onChange={(e) => personalDetails.bornDate = e.target.value} />
        <TextField required error={!!errors.phone} InputLabelProps={{ style: { color: errors.phone ? '#e6001a' : '#004AAD' } }} helperText={errors.phone ? (
          errors.phone.type === 'required' ? 'required field' :
            errors.phone.type === 'pattern' ? '00-0000000 format required' : '') : ' '} label="Phone" {...register("phone", { required: true, pattern: /^0[0-9]{1}-[0-9]{7}$/, })} defaultValue={personalDetails.phone} variant="standard" onChange={(e) => personalDetails.phone = e.target.value} />
        <TextField required error={!!errors.mobilePhone} InputLabelProps={{ style: { color: errors.mobilePhone ? '#e6001a' : '#004AAD' } }} helperText={errors.mobilePhone ? (
          errors.mobilePhone.type === 'required' ? 'required field' :
            errors.mobilePhone.type === 'pattern' ? '10 numbers required' : '') : ' '} label="Mobile phone"{...register("mobilePhone", { required: true, pattern: /^0[0-9]{9}$/, })} defaultValue={personalDetails.mobilePhone} variant="standard" onChange={(e) => personalDetails.mobilePhone = e.target.value} />
        {personalDetails.id == 0 && <TextField required error={!!errors.file} InputLabelProps={{ style: { color: errors.file ? '#e6001a' : '#004AAD' } }} helperText={errors.file ? (
          errors.file.type === 'required' ? 'required field' : '') : ' '} type="file"{...register("file", { required: "field is required" })} variant="standard" onChange={handleFileChange} />}
        <p className="red">* required fields</p>
      </div>
      <h2>Corona details</h2>
      <p className="red">{errorText}</p>
      <Table  >
        <TableHead>
          <TableRow>
            <TableCell sx={{ backgroundColor: "#acdaff", color: "#004AAD" }} align="center"><b>The vaccination number</b></TableCell>
            <TableCell sx={{ backgroundColor: "#acdaff", color: "#004AAD" }} align="center"><b>Date of receiving the vaccine</b></TableCell>
            <TableCell sx={{ backgroundColor: "#acdaff", color: "#004AAD" }} align="center"><b>The manufacturer of the vaccine</b></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          <TableRow>
            <TableCell align="center">1</TableCell>
            <TableCell align="center">
              <TextField error={!!errors.firstDate} defaultValue={personalDetails.id == 0 ? "" : (personalDetails.coronaDetails.firstVaccinationDate != "1900-01-01T00:00:00" ? personalDetails.coronaDetails.firstVaccinationDate.slice(0, 10) : '')} type="date" variant="standard" onChange={(e) => { personalDetails.coronaDetails.firstVaccinationDate = e.target.value }} />
            </TableCell>
            <TableCell align="center">
              <TextField defaultValue={personalDetails.coronaDetails.firstmanufacturerVaccination} variant="standard" onChange={(e) => { personalDetails.coronaDetails.firstmanufacturerVaccination = e.target.value }} />
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell align="center">2</TableCell>
            <TableCell align="center">
              <TextField defaultValue={personalDetails.id == 0 ? "" : (personalDetails.coronaDetails.secondVaccinationDate != "1900-01-01T00:00:00" ? personalDetails.coronaDetails.secondVaccinationDate.slice(0, 10) : '')} type="date" variant="standard" onChange={(e) => { personalDetails.coronaDetails.secondVaccinationDate = e.target.value }} />
            </TableCell>
            <TableCell align="center">
              <TextField defaultValue={personalDetails.coronaDetails.secondmanufacturerVaccination} variant="standard" onChange={(e) => { personalDetails.coronaDetails.secondmanufacturerVaccination = e.target.value }} />
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell align="center">3</TableCell>
            <TableCell align="center">
              <TextField defaultValue={personalDetails.id == 0 ? "" : (personalDetails.coronaDetails.thirdVaccinationDate != "1900-01-01T00:00:00" ? personalDetails.coronaDetails.thirdVaccinationDate.slice(0, 10) : '')} type="date" variant="standard" onChange={(e) => { personalDetails.coronaDetails.thirdVaccinationDate = e.target.value }} />
            </TableCell>
            <TableCell align="center">
              <TextField defaultValue={personalDetails.coronaDetails.thirdmanufacturerVaccination} variant="standard" onChange={(e) => { personalDetails.coronaDetails.thirdmanufacturerVaccination = e.target.value }} />
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell align="center">4</TableCell>
            <TableCell align="center">
              <TextField defaultValue={personalDetails.id == 0 ? "" : (personalDetails.coronaDetails.fourthVaccinationDate != "1900-01-01T00:00:00" ? personalDetails.coronaDetails.fourthVaccinationDate.slice(0, 10) : '')} type="date" variant="standard" onChange={(e) => { personalDetails.coronaDetails.fourthVaccinationDate = e.target.value }} />
            </TableCell>
            <TableCell align="center">
              <TextField defaultValue={personalDetails.coronaDetails.fourthmanufacturerVaccination} variant="standard" onChange={(e) => { personalDetails.coronaDetails.fourthmanufacturerVaccination = e.target.value }} />
            </TableCell>
          </TableRow>
        </TableBody>
      </Table>
      <div style={{ display: 'flex', justifyContent: 'center' }}>
        <p >positive result date
          <TextField type="date" variant="standard" defaultValue={personalDetails.id == 0 ? "" : (personalDetails.coronaDetails.positiveResultDate != "1900-01-01T00:00:00" ? personalDetails.coronaDetails.positiveResultDate.slice(0, 10) : '')} onChange={(e) => { personalDetails.coronaDetails.positiveResultDate = e.target.value }} />
        </p>
        <p style={{ marginLeft: '50px' }}>recovery date
          <TextField error={!!errors.recoveryDate} type="date" variant="standard" defaultValue={personalDetails.id == 0 ? "" : (personalDetails.coronaDetails.recoveryDate != "1900-01-01T00:00:00" ? personalDetails.coronaDetails.recoveryDate.slice(0, 10) : '')} onChange={(e) => { personalDetails.coronaDetails.recoveryDate = e.target.value }} />
        </p>
      </div>
      <Button sx={{ backgroundColor: "#acdaff", color: "#004AAD" }} variant="outlined" type="submit" disabled={!isValid}>
        {personalDetails.id == 0 ? 'ADD' : 'UPDATE'}
      </Button>
    </form>
  </>);
}

export default AddUpdateDetails;