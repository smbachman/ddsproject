(function (DDS) {
  
  let errorLoggingIn = false;

  function loadPatients() {
    m.request({
      method: 'GET',
      url: 'api/Patients',
      user: DDS.username,
      password: DDS.password
    })
    .then(data => {
      errorLoggingIn = false;
      DDS.patients = data;
    })
    .catch(ex => {
      errorLoggingIn = true;
    });
  }

  DDS.views.Login = {    
    view: () => m('div', [
      m('form', {
        onsubmit: e => {
          e.preventDefault();
        }        
      }, [
        m('label', 'Username'),
        m('span', ' '),
        m('input[type=text]', {
          oninput: e => DDS.username = e.target.value            
        }),
        m('span', '  '),
        m('label', 'Password'),
        m('span', ' '),
        m('input[type=password]', {
          oninput: e => DDS.password = e.target.value            
        }),
        m('span', '  '),
        m('button', { onclick: loadPatients }, 'Login')
      ]),
      errorLoggingIn ? m('i', 'Your username or password is incorrect. Please try again.') : null
    ])
  };

})(DDS);