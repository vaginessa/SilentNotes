﻿// Copyright © 2018 Martin Stoeckli.
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.

using SilentNotes.HtmlView;
using SilentNotes.Services;
using SilentNotes.ViewModels;

namespace SilentNotes.Controllers
{
    /// <summary>
    /// Controller to show a <see cref="CloudStorageOauthWaitingViewModel"/> in an (Html)view.
    /// </summary>
    public class CloudStorageOauthWaitingController : ControllerBase
    {
        private CloudStorageOauthWaitingViewModel _viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudStorageOauthWaitingController"/> class.
        /// </summary>
        /// <param name="viewService">Razor view service which can generate the HTML view.</param>
        public CloudStorageOauthWaitingController(IRazorViewService viewService)
            : base(viewService)
        {
        }

        /// <inheritdoc/>
        protected override IViewModel GetViewModel()
        {
            return _viewModel;
        }

        /// <inheritdoc/>
        public override void ShowInView(IHtmlView htmlView, KeyValueList<string, string> variables)
        {
            base.ShowInView(htmlView, variables);
            _viewModel = new CloudStorageOauthWaitingViewModel(
                Ioc.GetOrCreate<INavigationService>(),
                Ioc.GetOrCreate<ILanguageService>(),
                Ioc.GetOrCreate<ISvgIconService>(),
                Ioc.GetOrCreate<IBaseUrlService>(),
                Ioc.GetOrCreate<IStoryBoardService>(),
                Ioc.GetOrCreate<IFeedbackService>());

            Bindings.BindCommand("GoBack", _viewModel.GoBackCommand);

            string html = _viewService.GenerateHtml(_viewModel);
            View.LoadHtml(html);
        }
    }
}
