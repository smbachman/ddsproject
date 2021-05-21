(function (DDS) {

  let newPatient = {};
  let showForm = false;

  function addPatient() {
    m.request({
      method: 'POST',
      url: 'api/Patients',
      user: DDS.username,
      password: DDS.password,
      body: newPatient
    })
    .then(data => {
      DDS.patients = [...DDS.patients, data];
    })
    .finally(() => {
      newPatient = {};
      showForm = false;
    });
  }
  
  DDS.views.AddPatient = {
    view: () => DDS.patients.some(_ => true) && showForm 
      ? m('form', {
        onsubmit: e => {
          e.preventDefault();
        }        
      }, [
        m('label', 'First Name'),
        m('span', ' '),
        m('input[type=text]', {
          oninput: e => newPatient.firstName = e.target.value,
          style: 'width: 100px'
        }),
        m('span', '  '),
        m('label', 'Last Name'),
        m('span', ' '),
        m('input[type=text]', {
          oninput: e => newPatient.lastName = e.target.value,
          style: 'width: 100px'
        }),
        m('span', '  '),
        m('label', 'DOB'),
        m('span', ' '),
        m('input[type=text]', {
          oninput: e => newPatient.dateOfBirth = e.target.value,
          style: 'width: 100px'
        }),
        m('span', '  '),
        m('button', { onclick: addPatient }, 'Add Patient')
      ]) 
      : DDS.patients.some(_ => true) ? m('button', { onclick: () => showForm = true }, 'Add Patient') : null
  };
  
})(DDS);