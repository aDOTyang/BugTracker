<?php $__env->startSection('title'); ?>Clipboard
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Clipboard</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Forms</li>
		<li class="breadcrumb-item">Form Widgets</li>
		<li class="breadcrumb-item active">Clipboard</li>
	<?php echo $__env->renderComponent(); ?>
	
	<div class="container-fluid">
		<div class="row">
			<div class="col-sm-12 col-md-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Clipboard On Text Input</h5>
					</div>
					<div class="card-body">
						<div class="clipboaard-container">
							<p class="card-description">Cut/copy from text input</p>
							<input class="form-control" id="clipboardExample1" type="text" placeholder="type some text to copy / cut" />
							<div class="mt-3">
								<button class="btn btn-primary btn-clipboard" type="button" data-clipboard-action="copy" data-clipboard-target="#clipboardExample1"><i class="fa fa-copy"></i> Copy</button>
								<button class="btn btn-secondary btn-clipboard-cut" type="button" data-clipboard-action="cut" data-clipboard-target="#clipboardExample1"><i class="fa fa-cut"></i> Cut</button>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-md-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Clipboard On Textarea</h5>
					</div>
					<div class="card-body">
						<div class="clipboaard-container">
							<p class="card-description">Cut/copy from textarea</p>
							<textarea class="form-control" id="clipboardExample2" rows="1" spellcheck="false">
	Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has
							</textarea>
							<div class="mt-3">
								<button class="btn btn-primary btn-clipboard" type="button" data-clipboard-action="copy" data-clipboard-target="#clipboardExample2"><i class="fa fa-copy"></i> Copy</button>
								<button class="btn btn-secondary btn-clipboard-cut" type="button" data-clipboard-action="cut" data-clipboard-target="#clipboardExample2"><i class="fa fa-cut"></i> Cut</button>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-md-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Clipboard On Paragraph</h5>
					</div>
					<div class="card-body">
						<div class="clipboaard-container">
							<p class="card-description">Copy from Paragraph</p>
							<h6 class="border rounded card-body f-w-300" id="clipboardExample3">
								Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
							</h6>
							<div class="mt-3">
								<button class="btn btn-primary btn-clipboard" type="button" data-clipboard-action="copy" data-clipboard-target="#clipboardExample3"><i class="fa fa-copy"></i> Copy</button>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-md-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Copy Portion From Paragraph</h5>
					</div>
					<div class="card-body">
						<div class="clipboaard-container">
							<p class="card-description">Copy Portion From Paragraph</p>
							<h6 class="border rounded card-body f-w-300">
								Lorem ipsum <span class="bg-primary text-white p-1" id="clipboardExample4">dolor sit amet</span>, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
							</h6>
							<div class="mt-3">
								<button class="btn btn-primary btn-clipboard" type="button" data-clipboard-action="copy" data-clipboard-target="#clipboardExample4"><i class="fa fa-copy"></i> Copy highlighted text</button>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>	
	
	<?php $__env->startPush('scripts'); ?>
	<script src="<?php echo e(asset('assets/js/clipboard/clipboard.min.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/clipboard/clipboard-script.js')); ?>"></script>
	<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/forms/clipboard.blade.php ENDPATH**/ ?>