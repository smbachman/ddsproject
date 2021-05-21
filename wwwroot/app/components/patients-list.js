(function (DDS) {

  function deletePatient(id) {
    m.request({
      method: 'DELETE',
      url: `api/Patients/${id}`,
      user: DDS.username,
      password: DDS.password,      
    })
    .then(() => {
      DDS.patients = DDS.patients.filter(p => p.id != id);
    });
  }
  
  DDS.views.PatientsList = {
    view: () => [
      m('h3', DDS.patients.some(_ => true) ? 'Patient List' : ''),
      m('ul', DDS.patients.map(patient => 
        m('li', [
          `${patient.firstName} ${patient.lastName} (dob: ${patient.dateOfBirth}) `, 
          m('button', { title: 'Delete', onclick: () => deletePatient(patient.id) }, 'X')
        ])
      ))
    ]    
  };
  
})(DDS);