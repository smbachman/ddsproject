(function (DDS) {
  
  DDS.views.Main = {
    view: () => m('div', [
      m(DDS.views.Login),        
      m(DDS.views.PatientsList),
      m(DDS.views.AddPatient)
    ])      
  };
  
})(DDS);