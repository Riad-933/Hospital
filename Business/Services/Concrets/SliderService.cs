using Business.Exceptions;
using Business.Extension;
using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrets
{
    public class SliderService : ISliderService
    {
        public ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _env;

        public SliderService(ISliderRepository sliderRepository, IWebHostEnvironment env)
        {
            _sliderRepository = sliderRepository;
            _env = env;
        }


        public async Task AddSliderAsync(Slider slider)
        {
            if (slider.ImageFile == null)
                throw new FileNullReferenceException("fayla ad qoy");

            slider.ImageURL = Helper.SaveFile(_env.WebRootPath, @"uploads\sliders", slider.ImageFile);

            await _sliderRepository.AddAsync(slider);
            await _sliderRepository.CommitAsync();
        }

        public void DeleteSlider(int id)
        {
            var existSlider = _sliderRepository.Get( x=> x.Id == id );
            if(existSlider == null) throw new EntityNotFounException("tapilmadi blin");
        }

        public List<Slider> GetAllSlider(Func<Slider, bool>? func = null)
        {
            return _sliderRepository.GetAll(func);
        }

        public Slider GetSlider(Func<Slider, bool>? func = null)
        {
            return _sliderRepository.Get(func);
        }

        public void UpdateSlider(int id, Slider newSlider)
        {
            var oldSlider = _sliderRepository.Get(x => x.Id == id);

            if (oldSlider == null) throw new EntityNotFounException("kohnelerden heckim qalmiyib");

            if(newSlider.ImageFile != null)
            {

                Helper.DeleteFile(_env.WebRootPath, @"uploads\sliders", newSlider.ImageURL);

                oldSlider.ImageURL = Helper.SaveFile(_env.WebRootPath, @"uploads\sliders", newSlider.ImageFile);
            }

            oldSlider.Title = newSlider.Title;
            oldSlider.Description = newSlider.Description;
            oldSlider.RedirectURL = newSlider.RedirectURL;

            _sliderRepository.Commit();

        }
    }
}
